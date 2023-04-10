using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDanger : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0F;

    private Vector3 direction;

    private Character character;

    protected virtual void Start()
    {
        direction = transform.up * 1F;
        character = FindObjectOfType<Character>();
    }

    protected virtual void Update()
    {
        if (character.transform.position.y >= 5F) Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Character ischaracter = collider.GetComponent<Character>();
        //Debug.Log(gameObjects);
        if (ischaracter)
        {
            ischaracter.ReceiveDamage(5);
        }else Destroy(collider.gameObject);
    }
}
