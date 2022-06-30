using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public int enemyHealth;
    public int enemyAttack;
    public int enemySpecial;
    public int enemySpeed;

    public EnemyData newStats;
    private Collision2D col;

    void Start()
    {
        AssignEnemyData(newStats);
    }
    void Update()
    {
        if (this.enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AssignEnemyData(EnemyData enemyData)
    {
        this.enemyHealth = enemyData.enemyHealth;
        this.enemyAttack = enemyData.enemyAttack;
        this.enemySpecial = enemyData.enemySpecial;
        this.enemySpeed = enemyData.enemySpeed;
        //return this;
    }

}

