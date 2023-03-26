using UnityEngine;
using System.Collections;
using System.Linq;

public class MoveableMonster : Monster
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private float up = 0.6F;
    [SerializeField]
    private float right = 0.5F;

    private Vector3 direction;
    

    private SpriteRenderer sprite;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        direction = transform.right;
    }

    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }

    private void Move()
    {
        sprite.flipX = direction.x > 0.0F;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.right * direction.x * right + transform.up * up, 0.1F);//
        Collider2D[] colliders1 = Physics2D.OverlapCircleAll(transform.position + transform.right * direction.x * right, 0.1F);

        if ((colliders.Length > 1 && colliders.All(x => !x.GetComponent<Character>())) || (colliders1.Length == 0 && colliders1.All(x => !x.GetComponent<Character>()))) direction *= -1.0F;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
