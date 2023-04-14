using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    int levelComplete;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        level2.interactable = false;
        level3.interactable = false;
        level4.interactable = false;
        level5.interactable = false;

        switch (levelComplete)
        {
            case 1:
                level2.interactable = true;
                break;
            case 2:
                level2.interactable = true;
                level3.interactable = true;
                break;
            case 3:
                level2.interactable = true;
                level3.interactable = true;
                level4.interactable = true;
                break;
            case 4:
                level2.interactable = true;
                level3.interactable = true;
                level4.interactable = true;
                level5.interactable = true;
                break;
            case 5:
                level2.interactable = true;
                level3.interactable = true;
                level4.interactable = true;
                level5.interactable = true;
                break;
        }
    }

    public void Statistic()
    {
        string t;
        GameObject obj;

        for (int i = 1; i < levelComplete + 1; i++)
        {
            t = "Stars" + i.ToString();
            obj = GameObject.Find(t);
            obj.GetComponent<Text>().text = " Stars: " + PlayerPrefs.GetInt(t).ToString();
            t = "Time" + i.ToString();
            obj = GameObject.Find(t);
            obj.GetComponent<Text>().text = " Time: " + PlayerPrefs.GetString(t);
        }
    }

    public void Reset()
    {
        level2.interactable = false;
        level3.interactable = false;
        level4.interactable = false;
        level5.interactable = false;
        string t;
        GameObject obj;

        for (int i = 1; i < levelComplete + 1; i++)
        {
            t = "Stars" + i.ToString();
            obj = GameObject.Find(t);
            obj.GetComponent<Text>().text = " Stars: 0";
            PlayerPrefs.DeleteKey(t);
            t = "Time" + i.ToString();
            obj = GameObject.Find(t);
            obj.GetComponent<Text>().text = " Time: 00:00";
            PlayerPrefs.DeleteKey(t);
        }
        PlayerPrefs.SetInt("LevelComplete", 0);
        //PlayerPrefs.DeleteAll();
    }

    public void CangeScenes(int numberScenes)
    {
        if(numberScenes == 0) SceneManager.LoadScene(levelComplete + 1);
        else SceneManager.LoadScene(numberScenes);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
