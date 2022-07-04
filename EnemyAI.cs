using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform enemyPosition;

    public int enemyCoordinateX;
    public int enemyCoordinateY;

    int oppBackBorderX = 1;
    int oppFrontBorderX = 4;

    public float moveTimer;
    float setTimer;
    void Start()
    {
        setTimer = moveTimer;
    }


    void Update()
    {
        if (moveTimer > 0)
        {
            moveTimer = moveTimer -= Time.deltaTime;
        }
        else
        {
            enemyMovement(chooseDirection());
            moveTimer = setTimer;
        }


    }
    string chooseDirection()
    {
        bool validDirection = false;
        string choice = null;

        while (!validDirection)
        {
            string[] directions = new string[] { "up", "down", "forward", "backward" };
            int switcher = Random.Range(0, 3);
            choice = directions[switcher];

            if (choice == "up" && enemyCoordinateY == 1)
            {
                validDirection = false;
                Debug.Log("up");
            }
            else if (choice == "down" && enemyCoordinateY == -1)
            {
                validDirection = false;
                Debug.Log("south");
            }
            else if (choice == "forward" && enemyCoordinateX == oppFrontBorderX)
            {
                validDirection = false;
                Debug.Log("forward");
            }
            else if (choice == "backward" && enemyCoordinateX == oppBackBorderX)
            {
                validDirection = false;
                Debug.Log("backward");
            }
            else
            {
                validDirection = true;

            }
        }


        return choice;

    }
    void enemyMovement(string Direction)
    {
        if (Direction == "up")
        {
            enemyCoordinateY += 1;
            enemyPosition.position = new Vector2(enemyPosition.position.x, enemyPosition.position.y + 2);
        }
        else if (Direction == "down")
        {
            enemyCoordinateY -= 1;
            enemyPosition.position = new Vector2(enemyPosition.position.x, enemyPosition.position.y - 2);
        }
        else if (Direction == "forward")
        {
            enemyCoordinateX += 1;
            enemyPosition.position = new Vector2(enemyPosition.position.x + 2, enemyPosition.position.y);
        }
        else if (Direction == "backward")
        {
            enemyCoordinateY -= 1;
            enemyPosition.position = new Vector2(enemyPosition.position.x - 2, enemyPosition.position.y);
        }
    }
}
    //void enemyAttack
