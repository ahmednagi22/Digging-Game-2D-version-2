using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey(KeyCode.Alpha1))
            {
              //  print("DownArrow key was pressed");

                SceneManager.LoadScene(0);
            }
            else if(Input.GetKey(KeyCode.Alpha2))
            {
               // print("UpArrow key was pressed");

                SceneManager.LoadScene(1);
            }
            else if(Input.GetKey(KeyCode.Alpha3))
            {
               // print("RightArrow key was pressed");

                SceneManager.LoadScene(2);
            }
            
        }
        
      
        
    
}
