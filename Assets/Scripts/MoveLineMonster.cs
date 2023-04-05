using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLineMonster : Monster
{
    [SerializeField]
    private float speed = 5.0F;
    [SerializeField]
    private float x1 = 0F;
    //[SerializeField]
    private float y1, y2;// = transform.position.y;
    [SerializeField]
    private float x2 = 0F;
    //[SerializeField]
    //private float y2 = 0F;

    private Vector3 pos1, pos2, nextPos;
    private SpriteRenderer sprite;

    protected override void Start()
    {
        y1= transform.position.y;
        y2 = transform.position.y;
        pos1 = new Vector3(x1, y1, 0F);
        pos2 = new Vector3(x2, y2, 0F);
        nextPos = pos1;
    }

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Update()
    {
        Move();
    }

    private void Move()
    {
        //sprite.flipX = nextPos == pos2;

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        if (transform.position == pos1)
        {
            nextPos = pos2;
            sprite.flipX = true;
        }
        if (transform.position == pos2)
        {
            nextPos = pos1;
            sprite.flipX = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1, pos2);
    }
}
