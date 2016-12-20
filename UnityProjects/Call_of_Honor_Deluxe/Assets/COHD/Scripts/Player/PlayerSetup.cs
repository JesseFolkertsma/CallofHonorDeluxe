using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDistable;
    [SerializeField]
    string remotePlayerLayerName = "RemotePlayer";

    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            SetupRemoteLayer();
        }
        SetupPlayerName();
    }

    void SetupPlayerName()
    {
        string id = "Player " + GetComponent<NetworkIdentity>().netId;
        gameObject.name = id;
    }

    void SetupRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remotePlayerLayerName);
    }

    void DisableComponents()
    {
        for (int i = 0; i < componentsToDistable.Length; i++)
        {
            componentsToDistable[i].enabled = false;
        }
    }
}
