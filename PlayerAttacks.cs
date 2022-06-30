using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : Arena
{
    public RaycastHit2D hit;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 origin = new Vector2(playerPosition.position.x, playerPosition.position.y);
            hit = Physics2D.Raycast(origin, Vector2.right, Mathf.Infinity);
            if (hit.transform.tag == "Enemy")
            {
                EnemyObject target = hit.transform.gameObject.GetComponent<EnemyObject>();
                target.enemyHealth -= 1;      
                
            }
               
        }
    }
}
