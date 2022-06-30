using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public Transform playerPosition;
    public bool canMove = true;

    public int CoordinateX;
    public int CoordinateY;

    protected int backBorderX = 1;
    protected int frontBorderX = 4;

    void Start()
    {
     
    }

    void Update()
    {
        playerMovement(CoordinateX, CoordinateY);
    }

    void playerMovement(int x, int y)
    {
        x = CoordinateX;
        y = CoordinateY;

        if (Input.GetKeyDown(KeyCode.W))
        {
            int preVal = y + 1;            
            if (preVal != 2)
            {
                CoordinateY += 1;
                playerPosition.position = new Vector2(playerPosition.position.x, playerPosition.position.y + 2);
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.S))
        {
            int preVal = y - 1;
            if (preVal != -2)
            {
                CoordinateY -= 1;
                playerPosition.position = new Vector2(playerPosition.position.x, playerPosition.position.y - 2);
            }
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (x > backBorderX)
            {
                CoordinateX -= 1;
                playerPosition.position = new Vector2(playerPosition.position.x - 2, playerPosition.position.y);
            }           
        }
            
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (x < frontBorderX)
            {
                CoordinateX += 1;
                playerPosition.position = new Vector2(playerPosition.position.x + 2, playerPosition.position.y);
            }
        }
    }
}
