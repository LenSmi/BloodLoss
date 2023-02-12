using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.Game;

public class Reparent : MonoBehaviour
{

    public GameObject parent;
    public GameObject player;
    public RespawnController respawnController;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == GameConstants.PlayerTag)
        {
            player.transform.SetParent(parent.transform,true);
            Blood blood = other.GetComponent<Blood>();
            blood.currentBlood += 0.2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == GameConstants.PlayerTag)
        {
            player.transform.SetParent(null, true);
            player.transform.position = respawnController.respawnLocations[0].position;
            
        }
    }
}
