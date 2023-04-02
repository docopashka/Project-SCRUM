using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spike : MonoBehaviour
{
    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.right * -1.0F + transform.up * -1.0F, 0.1F);//
        
        if (colliders.Length > 0 && colliders.All(x => x.GetComponent<Character>()))
        {
            rigidbody.gravityScale = 1;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            character.ReceiveDamage();
            Destroy(gameObject);
        }
        else Destroy(gameObject);
    }
}
