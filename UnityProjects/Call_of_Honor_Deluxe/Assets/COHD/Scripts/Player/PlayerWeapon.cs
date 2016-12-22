using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

    public WeaponTompson weapon;
    public Animator anim;

    public Transform cam;

    bool isShooting = false;

    void Update()
    {
        if (weapon != null)
        {
            weapon.GunUpdate();
            if (Input.GetButton("Fire1"))
            {
                weapon.Attack(cam);
                isShooting = true;
            }
            else
            {
                isShooting = false;
            }
            anim.SetBool("IsShooting", isShooting);

            if (Input.GetButtonDown("Fire2"))
            {
                anim.SetBool("Aiming", true);
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                anim.SetBool("Aiming", false);
            }

            if (Input.GetButtonDown("R"))
            {
                weapon.Reload();
                anim.SetTrigger("Reload");
            }
        }
    }
}
