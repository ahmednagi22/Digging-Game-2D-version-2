using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    public float volume;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    

    
    public void load()
    {
        SceneManager.LoadScene(PuaseMenu.Level);
    }
    
    
    public void QuitGame()
    {   print("quit");
        Application.Quit();
    }
}
