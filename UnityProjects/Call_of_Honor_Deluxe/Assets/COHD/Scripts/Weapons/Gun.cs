using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
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
    public void GunUpdate()
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
    
    public override bool Attack(Transform cam)
    {
        if (CanAttack)
        {
            RaycastHit hit;
            if(Physics.Raycast(cam.position, cam.forward, out hit, range, LayerMask.NameToLayer("LocalPlayer"))){
                if(hit.transform.tag == "Player")
                {
                    Debug.Log("Hit dat player " + hit.transform.name);
                }
            }
            bullets--;
            AttackWait();
            return true;
        }
        return false;
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
