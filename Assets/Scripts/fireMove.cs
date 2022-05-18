using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMove : MonoBehaviour
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
        if (!PuaseMenu.GameIsPaused)
        {
            transform.Translate(new Vector3(dir * 0.02f, 0, 0));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.dir *= -1;
    }
    

}
