using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    private string remoteLayer = "remoteLayer";
    private Camera sceneCamera;
    [SerializeField]
    Behaviour[] componentsToDisable;
    

    void Start ()
    {
        if (!isLocalPlayer)
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
                gameObject.layer = LayerMask.NameToLayer(remoteLayer);
            }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
                sceneCamera.gameObject.SetActive(false);
        }
       
    }
    public override void OnStartClient()
    {
        base.OnStartClient();
        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();
        GameManager.RegisterPlayer(netID, player);
    }
    void OnDisable()
    {
        if (sceneCamera != null)
            sceneCamera.gameObject.SetActive(true);


        GameManager.UnregisterPlayer(transform.name);
    }
}
