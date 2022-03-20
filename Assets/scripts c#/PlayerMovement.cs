using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int Score = 0;
    
    void Start()
    {
        
        
    }

    
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

        }
       
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gim")){
            
            Debug.Log(collision.name);
            //Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gems")){
            Destroy(collision.gameObject);
            Score += 100;
        }
          print(Score);

    }

}
