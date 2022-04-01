using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int Score = 0;
    private int health = 3;
    private Boolean gameOver = false;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walking",false);

    }


    void Update()
    {     
        anim.SetBool("walking",false);
        if(!gameOver){
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(-0.08f,0,0));
                mySprite.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(0.08f,0,0));
                mySprite.flipX = false;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(0,0.08f,0));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(0,-0.08f,0));
            }
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
        if (collision.gameObject.CompareTag("Gems"))
        {
            anim.SetTrigger("dig");

            Destroy(collision.gameObject);
            Score += 100;
            print(Score);
            


        }
        if (collision.gameObject.CompareTag("stone")||collision.gameObject.CompareTag("enemy")||collision.gameObject.CompareTag("Fire"))
        {
            
            if(health==0){
                if(!gameOver){
                    gameOver = true;//disabled temprorey for easy debuging
                    anim.SetTrigger("die");
                    print("Game Over!");
                }
            }
            health -= 1;
        }

    }

}
