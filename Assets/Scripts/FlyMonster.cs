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
}
