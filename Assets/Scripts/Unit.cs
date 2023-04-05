using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public virtual void ReceiveDamage(int damage = 1)
    {
        Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
