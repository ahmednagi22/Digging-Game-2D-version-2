using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class DestroyTilemap : MonoBehaviour
{    Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        tilemap=GetC
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter2D(Collision2D collision)
        {
            
            tilemap.SetTile(new Vector3Int(-7,3,0), null);
                Destroy(collision.gameObject);
                
              
    
        }
        private void OnCollisionEnter2D(Collision2D collision)
            {
                if (collision.gameObject.CompareTag("Ground")){
                   // Destroy(collision.gameObject);
                    print("collision");}
                  
        
            }
}
