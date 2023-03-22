using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyMonster : Monster
{
    private SpriteRenderer sprite;
    [SerializeField]
    private AIPath aiPath;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Update()
    {
        sprite.flipX = aiPath.desiredVelocity.x > 0.01f;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if (bullet)
        {
            ReceiveDamage();
            Debug.Log(1);
        }

        Character character = collider.GetComponent<Character>();

        if (character)
        {
            character.ReceiveDamage();
        }
    }
}
