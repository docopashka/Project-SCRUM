using UnityEngine;
using System.Collections;

public class Monster : Unit
{
    protected virtual void Awake() 
    {
       // animator = GetComponent<Animator>();
    }
    protected virtual void Start() { }
    protected virtual void Update() {
        //State = CharState1.Idle;
    }
    [SerializeField]
    private int damage = 1;
    //private CharState1 State
    //{
    //    get { return (CharState1)animator.GetInteger("State"); }
    //    set { animator.SetInteger("State", (int)value); }
    //}
    //private Animator animator;

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if (bullet)
        {
            //State = CharState1.Hit;
            ReceiveDamage();
        }

        Character character = collider.GetComponent<Character>();

        if (character)
        {
            character.ReceiveDamage(damage);
        }
    }
}

//public enum CharState1
//{
//    Idle,
//    Hit,
//    Run
//}
