using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static SaveManager instance;

    public int score;
    public int level;

    void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void SaveProgress() {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("level", level);
    }

    public void LoadProgress() {
        if (PlayerPrefs.HasKey("score")) {
            score = PlayerPrefs.GetInt("score");
        }
        if (PlayerPrefs.HasKey("level")) {
            level = PlayerPrefs.GetInt("level");
        }
    }
}