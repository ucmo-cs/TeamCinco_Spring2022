//Hayden White
//Last Update: April 4th, 2022
//This script handles the respawning of collectible items.

using UnityEngine;

public class RespawnCoin : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            Respawn();
        }
        //This handles a voluntary respawn.
    }

    public void Respawn(){
        this.GetComponent<Renderer>().enabled = true;
        this.GetComponent<Collider2D>().enabled = true;
    }
    //This tells the coin to reappear and become "active" during a respawn.
}
