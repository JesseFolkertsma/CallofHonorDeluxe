using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDistable;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDistable.Length; i++)
            {
                componentsToDistable[i].enabled = false;
            }
        }
    }
}
