using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public float enemyMaxHealth;
    public float enemyHealth;
    public float enemyAttack;
    public float enemySpecial;
    public float enemySpeed;

    public EnemyData newStats;

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
        this.enemyMaxHealth = enemyData.enemyMaxHealth;
        this.enemyHealth = enemyData.enemyHealth;
        this.enemyAttack = enemyData.enemyAttack;
        this.enemySpecial = enemyData.enemySpecial;
        this.enemySpeed = enemyData.enemySpeed;
        //return this;
    }

}

