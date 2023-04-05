using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;

    public GameObject PauseGameMenu;

    public GameObject DeathMenu;

    public GameObject End;

    public GameObject StarBar;

    private Transform[] stars = new Transform[3];

    private Character character;

    private void Awake()
    {
        PauseGameMenu.SetActive(false);
        PauseGame = false;
        DeathMenu.SetActive(false);
        End.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("Canvas/PauseButton")) 
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (DeathMenu.activeInHierarchy) 
        {
            Time.timeScale = 0f;
            PauseGame = true;
            Destroy(PauseGameMenu);
            //GameObject.Find("Canvas/Bar").SetActive(false);
            Destroy(GameObject.Find("Canvas/Bar"));
        }
        if (End.activeInHierarchy)
        {
            character = FindObjectOfType<Character>();
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = StarBar.transform.GetChild(i);
                if (i < character.Stars) stars[i].gameObject.SetActive(true);
                else stars[i].gameObject.SetActive(false);
            }
            Time.timeScale = 0f;
            PauseGame = true;
            Destroy(PauseGameMenu);
            Destroy(GameObject.Find("Canvas/Bar"));
            //GameObject.Find("Canvas/Bar").SetActive(false);
            //Destroy(GameObject.Find("Canvas/PauseButton"));
        }
    }

    public void Resume() 
    {
        PauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        PauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LosdMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
