using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera camScene;

    //disable elements of componentsToDisable[i] of other player
    private void Start()
    {
        if(!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            camScene = Camera.main;
            if(camScene != null)
            {
                camScene.gameObject.SetActive(false);
            }
            
        }
    }


    //enable main camera for rendering
    private void OnDisable()
    {
        if (camScene != null)
        {
            camScene.gameObject.SetActive(true);
        }
    }
}
