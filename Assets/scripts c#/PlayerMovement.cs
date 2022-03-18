using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    //bool pressButton = false;
    void Update()
    {     
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.02f,0,0));
            mySprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.02f,0,0));
            mySprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,0.02f,0));
;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0,-0.02f,0));

        }/* IEnumerator TimeDelay()
             {
                 
                 yield return new WaitForSeconds(100);
                 print("TimeDelay");
             }*/
        
           // StartCoroutine(TimeDelay());
       
    }
   
   
}
