using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Pickup : NetworkBehaviour {

    void Start()
    {
        NetworkServer.SpawnWithClientAuthority(gameObject, gameObject);
    }

    public void Pick(NetworkConnection conn)
    {
        
    }

}
