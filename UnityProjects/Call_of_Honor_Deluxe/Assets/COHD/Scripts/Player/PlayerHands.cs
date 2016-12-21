using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using System.Collections;

public class PlayerHands : NetworkBehaviour {

    [SerializeField]
    Transform cam;

    [SerializeField]
    float throwForce = 10f;

    public LayerMask mask;
    public GameObject holding;
    public GameObject preFab;

	void Update()
    {
        if (holding != null)
        {
            Holding();
        }
        else {
            if (Input.GetButtonDown("Interact"))
            {
                Grab();
            }
        }
    }

    [Command]
    void CmdSpawn()
    {
        RpcSpawn();
    }

    [ClientRpc]
    void RpcSpawn()
    {
        GameObject g = (GameObject)Instantiate(preFab, transform.position + transform.forward * 2, transform.rotation);
        NetworkServer.Spawn(g);
    }

    void Holding()
    {
        holding.transform.position = cam.position + cam.forward * 2;
        if (Input.GetButtonDown("Interact"))
        {
            Drop();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    void Grab()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, 100, mask))
        {
            if(hit.transform.tag == "Pickup")
            {
                holding = hit.transform.gameObject;
                hit.transform.GetComponent<NetworkIdentity>().AssignClientAuthority(GetComponent<PlayerSetup>().connectionToClient);
            }
        }
    }

    void Drop()
    {
        holding = null;
    }

    void Throw()
    {
        holding.GetComponent<Rigidbody>().velocity = cam.forward * throwForce;
        holding = null;
    }
}
