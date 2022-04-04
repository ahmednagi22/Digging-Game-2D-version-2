using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private int Score = 0;
    private int health = 5;
    private Boolean gameOver = false;
    private Animator anim;
    private int RATIO_OF_SCORE_TO_HEALTH = 7;
    private int MaximumHealth = 5;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walking",false);
    }


    void Update()
    {
        healthText.text = "Health: "+health+"/"+MaximumHealth+"";
        scoreText.text = "Score:"+Score+"";
        if (Score >= RATIO_OF_SCORE_TO_HEALTH && health < MaximumHealth)
        {
            for (int i = 0; i < Score/RATIO_OF_SCORE_TO_HEALTH; i++)
            {
                Score -= RATIO_OF_SCORE_TO_HEALTH;
                health += 1;
            }
            print("Score = " + Score);
            print("Health = " +health);
        }

        anim.SetBool("walking",false);
        if(!gameOver){
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(-0.02f,0,0));
                mySprite.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(0.02f,0,0));
                mySprite.flipX = false;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(0,0.02f,0));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(0,-0.02f,0));
            }
        }
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gim")){
            //Debug.Log(collision.name);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gems"))
        {
            anim.SetTrigger("dig");

            Destroy(collision.gameObject);
            Score += 1;
            print("Score = " + Score);
        }
        if (collision.gameObject.CompareTag("stone") && collision.gameObject.transform.position.y > transform.position.y)
        {
            
            if(health==1){
                if(!gameOver)
                {
                    health -= 1;
                    gameOver = true;//disabled temprorey for easy debuging
                    anim.SetTrigger("die");//disabled temprorey for easy debuging
                    print("Game Over!");
                    return;
                }
            }
            if(!gameOver){
                health -= 1;
                anim.SetTrigger("hit");
                print("Health = " +health);
            }
        }

        if (collision.gameObject.CompareTag("Fire")||collision.gameObject.CompareTag("enemy"))
        {
            health = 0;
            if(!gameOver){
                gameOver = true;//disabled temprorey for easy debuging
                anim.SetTrigger("die");//disabled temprorey for easy debuging 
                print("Game Over!");
            }
        }
    }

}
