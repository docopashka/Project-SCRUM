using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;

    public GameObject PauseGameMenu;

    public GameObject DeathMenu;

    private void Awake()
    {
        PauseGameMenu.SetActive(false);
        PauseGame = false;
        DeathMenu.SetActive(false);
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
            Destroy(GameObject.Find("Canvas/PauseButton"));
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
