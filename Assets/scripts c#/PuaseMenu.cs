using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuaseMenu : MonoBehaviour
{
    static public bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {
                pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene("main menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
