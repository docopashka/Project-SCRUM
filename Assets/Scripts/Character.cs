using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : Unit
{
    [SerializeField]
    private int lives = 5;
    private int stars = 0;
    //public int level = 1;
    private GameObject timer;//GameObject
    public GameObject death;
    public GameObject end;
    private GameObject gun;
    public AudioSource shoot;
    public AudioSource jump;
    public AudioSource run;
    public AudioSource coin;

    int sceneIndex;
    int level;
    string scene;
    string levelStars;
    string levelTime;
    string time;

    void Start()
    {
        level = PlayerPrefs.GetInt("LevelComplete");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        scene = sceneIndex.ToString();
        levelStars = "Stars" + scene;
        levelTime = "Time" + scene;
    }

    public int Stars
    {
        get { return stars; }
        set
        {
            stars = value;
            coin.Play();
            starsBar.Refresh();
        }
    }
    private StarsBar starsBar;

    public int Lives
    {
        get { return lives; }
        set
        {
           if (value <= 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded = false;

    private Bullet bullet;

    //public void SavePlayer() //для кнопки сохранить
    //{
    //    SaveSystem.SavePlayer(this);
    //}


    //public void LoadPlayer()
    //{
    //    PlayerData data = SaveSystem.LoadPlayer();

    //    level = data.level;
    //    lives = data.health;
    //    stars = data.stars;

    //    Vector3 position;
    //    position.x = data.position[0];
    //    position.y = data.position[1];
    //    position.z = data.position[2];
    //    transform.position = position;

    //}
    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private SpriteRenderer gunSprite;

    private void Awake()
    {
        livesBar    = FindObjectOfType<LivesBar>();
        starsBar    = FindObjectOfType<StarsBar>();
        rigidbody   = GetComponent<Rigidbody2D>();
        animator    = GetComponent<Animator>();
        sprite      = GetComponentInChildren<SpriteRenderer>();
        bullet      = Resources.Load<Bullet>("Bullet");
        gun         = GameObject.FindWithTag("Gun");
        gunSprite   = gun.GetComponentInChildren<SpriteRenderer>();
        //death       = GameObject.FindWithTag("Death");//FindObjectOfType<Death>();
        //end         = GameObject.FindWithTag("End"); //FindObjectOfType<End>();
        timer        = GameObject.FindWithTag("Timer");//FindObjectOfType<Time>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = CharState.Idle;

        if (Input.GetButtonDown("Fire1") && (Time.timeScale != 0f)) Shoot();
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        gunSprite.flipX = direction.x < 0.0F;

        if (isGrounded)
        {
            State = CharState.Run;
            run.Play();
        }
    }

    private void Jump()
    {
        jump.Play();
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        shoot.Play();
        
        Vector3 position = gun.transform.position; //position.y += 0.5F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }

    public override void ReceiveDamage(int damage = 1)
    {
        Lives -= damage;

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);

        Debug.Log(lives);

        if (lives <= 0) Die();
    }

    protected override void Die()
    {
        State = CharState.Die;
        gameObject.GetComponent<Character>().enabled = false;
        death.SetActive(true);
        //time = GameObject.FindWithTag("Timer").text;
        //Debug.Log(time);
        //Instantiate(death, new Vector3(694, 314, 0), Quaternion.identity);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Destroy(gameObject);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;
        
        //Vector3 position = transform.position;
        //if (!isGrounded && position.y < -5) Die();

        if (!isGrounded) State = CharState.Jump;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        Bullet bullet = collider.gameObject.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject)
        {
            ReceiveDamage();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            end.SetActive(true);

            if(stars > 0 && level < sceneIndex)
            {
                time = timer.GetComponent<Text>().text;
                //Debug.Log(time);
                //Debug.Log(sceneIndex);
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
                PlayerPrefs.SetInt(levelStars, stars);
                PlayerPrefs.SetString(levelTime, time);
            }else if (stars > 0)
            {
                time = timer.GetComponent<Text>().text;
                if (stars > PlayerPrefs.GetInt(levelStars))
                {
                    PlayerPrefs.SetInt(levelStars, stars);
                    PlayerPrefs.SetString(levelTime, time);
                }
            }
        }
    }
}


public enum CharState
{
    Idle,
    Run,
    Jump,
    Hit,
    Die
}