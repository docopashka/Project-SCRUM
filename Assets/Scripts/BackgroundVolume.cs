using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundVolume : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string createdTag;

    private void Awake()
    {
        GameObject obj = GameObject.FindWithTag(this.createdTag);
        if (obj != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = this.createdTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
