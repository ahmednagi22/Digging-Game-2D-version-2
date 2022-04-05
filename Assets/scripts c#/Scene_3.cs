using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene_3 : MonoBehaviour
{
    private int Score = 0;
    public float speed = 0.02f;
    private int health = 5;
    private Boolean gameOver = false;
    private Animator anim;
    private int RATIO_OF_SCORE_TO_HEALTH = 7;
    private int MaximumHealth = 5;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public bool getDoorKey = false;
    public GameObject imageOfDoorKey;
    public SpriteRenderer player_image;
    public Animator animOfExitDoor;
    private SpriteRenderer mySprite;
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        StartCoroutine(BeginingAnimation());
        anim = GetComponent<Animator>();
        anim.SetBool("walking",false);
        imageOfDoorKey.SetActive(false);
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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(-speed,0,0));
                mySprite.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(speed,0,0));
                mySprite.flipX = false;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(0,speed,0));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("walking",true);
                transform.Translate(new Vector3(0,-speed,0));
            }
        }
    }

   /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gim")){
            //Debug.Log(collision.name);
            Destroy(collision.gameObject);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gems"))
        {
            anim.SetTrigger("dig");

            Destroy(collision.gameObject);
            Score += 1;
            print("Score = " + Score);
        }
        if (collision.gameObject.CompareTag("doorKey"))
        {
            Destroy(collision.gameObject);
            getDoorKey = true;
            imageOfDoorKey.SetActive(true);
        }
        if (collision.gameObject.CompareTag("ExitDoor")&&getDoorKey)
        {
            animOfExitDoor.SetBool("getDoorKey",true);
        }
        if (collision.gameObject.CompareTag("stone") && collision.gameObject.transform.position.y > transform.position.y)
        {
            
            if(health==1){
                if(!gameOver)
                {
                    health -= 1;
                    //gameOver = true;//disabled temprorey for easy debuging
                    //anim.SetTrigger("die");//disabled temprorey for easy debuging
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
                //gameOver = true;//disabled temprorey for easy debuging
                //anim.SetTrigger("die");//disabled temprorey for easy debuging 
                print("Game Over!");
            }
        }
    }

    IEnumerator BeginingAnimation()
    {
        player_image.enabled = false;
        gameOver = true;//to prevent the player from moving untile the game begin
        yield return new WaitForSeconds(1.9f);
        player_image.enabled = true;
        gameOver = false;//to prevent the player from moving untile the game begin
    }
}
