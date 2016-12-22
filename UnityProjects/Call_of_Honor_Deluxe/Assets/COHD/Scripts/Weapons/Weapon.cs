using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Weapon {

    public float damage;
    public float range;

    public abstract bool Attack(Transform cam);

    public virtual void Drop()
    {

    }
}
