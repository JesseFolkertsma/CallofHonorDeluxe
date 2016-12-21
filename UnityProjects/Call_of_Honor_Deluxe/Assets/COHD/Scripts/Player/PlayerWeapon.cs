using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

    public Weapon weapon;

    void Update()
    {
        if (weapon != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.Attack();
            }
        }
    }
}
