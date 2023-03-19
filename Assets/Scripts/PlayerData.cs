using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public float[] position;

    public PlayerData(Character character)
    {
        //level = character.level;
        health = character.Lives;

        position = new float[3];
        position[0] = character.transform.position.x;
        position[1] = character.transform.position.y;
        position[2] = character.transform.position.z;
    }
}
