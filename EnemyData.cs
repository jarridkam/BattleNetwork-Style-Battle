using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/New Enemy")]
public class EnemyData : ScriptableObject 
{
    public int enemyHealth;
    public int enemyAttack;
    public int enemySpecial;
    public int enemySpeed;
}
