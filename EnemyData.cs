using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/New Enemy")]
public class EnemyData : ScriptableObject 
{
    public float enemyMaxHealth;
    public float enemyHealth;
    public float enemyAttack;
    public float enemySpecial;
    public float enemySpeed;
}
