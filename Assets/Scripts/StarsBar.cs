using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsBar : MonoBehaviour
{
    private Transform[] stars = new Transform[3];

    private Character character;

    private void Awake()
    {
        character = FindObjectOfType<Character>();

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i] = transform.GetChild(i);
            stars[i].gameObject.SetActive(false);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < character.Stars) stars[i].gameObject.SetActive(true);
            else stars[i].gameObject.SetActive(false);
        }
    }
}
