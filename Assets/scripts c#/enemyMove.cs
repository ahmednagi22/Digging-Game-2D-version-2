using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public int dir = 1;

    private SpriteRenderer mySprite;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        transform.Translate(new Vector3(dir*0.025f,0,0));
        if(dir==-1){
            mySprite.flipX = true;
        }
        else if (dir == 1)
        {
            mySprite.flipX = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
            this.dir *= -1;
    }
}
