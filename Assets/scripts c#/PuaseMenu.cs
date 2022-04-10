using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuaseMenu : MonoBehaviour
{
    static public bool GameIsPaused = false;
    static public int Level;
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
        Time.timeScale = 1f;
        Resume();
        SceneManager.LoadScene(0);
        
    }
    public void Save()
    {
        Level = SceneManager.GetActiveScene().buildIndex;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
