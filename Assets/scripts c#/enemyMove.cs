using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public int dir = 1;
    private SpriteRenderer mySprite;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        transform.Translate(new Vector3(dir*0.02f,0,0));
        if(dir==-1){
            mySprite.flipX = true;
        }
        else if (dir == 1)
        {
            mySprite.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("stone") || collision.gameObject.CompareTag("Fire"))
            {
                Animator am = gameObject.GetComponent<Animator>();
                am.SetTrigger("enemy_killed");
                StartCoroutine(waitAndDestroy());
            }
            else
            {
                this.dir *= -1;
            }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!(collision.gameObject.CompareTag("stone") || collision.gameObject.CompareTag("Fire")))
        {
            this.dir *= -1;

        }
    }
    
    IEnumerator waitAndDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
