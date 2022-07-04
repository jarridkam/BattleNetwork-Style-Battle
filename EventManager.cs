using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void RayDelegates();
    public static event RayDelegates EnemyHitByRay;

    public delegate void AttackDelegate();
    public static event AttackDelegate ChargeAttack;

    public delegate void ButtonDelegate();
    public static event ButtonDelegate ButtonPressed;
    public static event ButtonDelegate ButtonLifted;

    public GameObject Player;

    float timer = 0;
    float holdTime;
    bool timing;

    void Start()
    {

    }

    void Update()
    {
        if (!timing)
            timer = 0;
        if (Input.GetKeyDown(KeyCode.Space))
            ButtonPressed();
        AttackEvent();
        
    }

    float StartTimer()
    {
        timing = true;
        timer += Time.deltaTime;
       // Debug.Log(timer);
        return timer;
    }
    float StopTimer(float timer)
    {
        timing = false;
        float time = timer;
        return time;
    }
    bool HoldingKey(float holdTime)
    {
        if (holdTime >= .5)
        {
            return true;
        }
        else if(holdTime < .5)
        {
            return false;
        }
        else
        {
            return false;
        }
    }
    void AttackEvent()
    {
        if (Input.GetKey(KeyCode.Space))
        {
           timer = StartTimer();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ButtonLifted();
            holdTime = StopTimer(timer);
            Debug.Log(holdTime);
            if (HoldingKey(holdTime) && ChargeAttack != null && !timing)
                ChargeAttack();
            else if (!HoldingKey(holdTime) && EnemyHitByRay != null && !timing)
                EnemyHitByRay();
        }
    }
}
