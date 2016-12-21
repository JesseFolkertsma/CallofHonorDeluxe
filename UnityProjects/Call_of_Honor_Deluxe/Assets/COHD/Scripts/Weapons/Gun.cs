using UnityEngine;
using System.Collections;
using System;

public class Gun : Weapon {

    public float fireRate;
    public int maxbullets;
    public int bullets;

    bool waitForRate;

    public bool CanAttack
    {
        get
        {
            if(bullets > 0 && !waitForRate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    float rateTimer;
    void Update()
    {
        if (waitForRate)
        {
            rateTimer += Time.deltaTime;
            if(rateTimer >= fireRate)
            {
                waitForRate = false;
            }
        }
    }
    
    public override void Attack()
    {
        if (CanAttack)
        {
            bullets--;
            AttackWait();
        }
    }

    public virtual void AttackWait()
    {
        rateTimer = 0;
        waitForRate = true;
    }

    public virtual void Reload()
    {
        bullets = maxbullets;
    }
}
