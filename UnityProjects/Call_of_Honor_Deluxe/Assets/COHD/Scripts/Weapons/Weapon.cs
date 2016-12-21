using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Weapon : MonoBehaviour {

    public float damage;
    public float range;

    public abstract void Attack();

    public virtual void Drop()
    {

    }
}
