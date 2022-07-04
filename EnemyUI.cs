using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Transform player;
    public Image healthbar;

    private RaycastHit2D hit;

    void OnEnable()
    {
        EventManager.EnemyHitByRay += updateHealthBar;
    }

    void OnDisable()
    {
        EventManager.EnemyHitByRay -= updateHealthBar;
    }

    void updateHealthBar()
    {
        try
        {
            Vector2 origin = new Vector2(player.position.x, player.position.y);
            hit = Physics2D.Raycast(origin, Vector2.right, Mathf.Infinity);
            if (hit.transform.tag == "Enemy")
            {
                EnemyObject target = hit.transform.gameObject.GetComponent<EnemyObject>();
                float health = target.enemyMaxHealth;
                Debug.Log(health);
                healthbar.fillAmount -= (1.0f / health);
            }
        }
        catch (NullReferenceException e)
        {
            
        }
        
    }


}
