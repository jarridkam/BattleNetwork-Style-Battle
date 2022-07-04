using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttacks : MonoBehaviour
{
    public GameObject chargeProjectile;
    public SpriteRenderer spriteRenderer;
    public Transform offSetPos;
    public Animator chargeAnimator;
    public Animator animator;
    public Sprite chargedBall;
    //public Animator playerAnimator;

    public float speed;
    public float charge;

    public bool charging;
    public bool maxChargeReached = false;

    private float maxCharge = 3f;

    private RaycastHit2D hit;
    private Transform newPosition;
    
    public string currentAnimation;

    const string SHOT_CHARGE = "shot_charge";
    const string SHOT_CHARGE_FULL = "shot_charge_full";

    private void Start()
    {
        chargeAnimator.enabled = false;
        newPosition = gameObject.transform;
  
        
    }
    private void Update()
    {
        if (charging)
            isCharging(chargeProjectile);
        if (!charging)
            spriteRenderer.sprite = null;
            
    }
    void OnEnable()
    {
        EventManager.ButtonPressed += startCharging;
        EventManager.ButtonLifted += stopCharging;
        EventManager.EnemyHitByRay += genericAttack;
        EventManager.ChargeAttack += chargeAttack;
    }


    void OnDisable()
    {
        EventManager.ButtonPressed -= startCharging;
        EventManager.ButtonLifted -= stopCharging;
        EventManager.EnemyHitByRay -= genericAttack;
        EventManager.ChargeAttack -= chargeAttack;
    }

    void startCharging()
    {
        charge = 0;
        charging = true;
        chargeAnimator.enabled = true;
       
    }
    void stopCharging()
    {
        charge = 0;
        charging = false;
        maxChargeReached = false;
        chargeAnimator.enabled = false;
    }
    void genericAttack()
    {
        try
        {
            Debug.Log("generic attack heard");
            RaycastHit2D hit;
            Vector2 origin = new Vector2(newPosition.transform.position.x, newPosition.transform.position.y);
            hit = Physics2D.Raycast(origin, Vector2.right, Mathf.Infinity);
            if (hit.transform.tag == "Enemy")
            {
                EnemyObject target = hit.transform.gameObject.GetComponent<EnemyObject>();
                target.enemyHealth -= 1;

            }
        }
        catch (NullReferenceException e)
        {
           
        }
       

    }
    void isCharging(GameObject projectile)
    {
        projectile.transform.localScale = new Vector3(1, 1, 0);

        if (!maxChargeReached)
        {
            AnimationChanger(SHOT_CHARGE_FULL);
            charge += Time.deltaTime;

        }

        if (charge >= maxCharge)
        {
            charge = maxCharge;
            AnimationChanger(SHOT_CHARGE_FULL);
            maxChargeReached = true;
        }
      
        charge += Time.deltaTime;
        if (charging)
        {
            projectile.transform.localScale += new Vector3(charge, charge, 0);
            //Debug.Log(charge);
        }
    }
    void chargeAttack()
    {
        Debug.Log("charge attack heard");
        GameObject chargeShot = Instantiate(chargeProjectile, offSetPos.position, transform.rotation) as GameObject;
        chargeShot.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }

    void AnimationChanger(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        {
            animator.Play(newAnimation);
            currentAnimation = newAnimation;
        }
    }
}
