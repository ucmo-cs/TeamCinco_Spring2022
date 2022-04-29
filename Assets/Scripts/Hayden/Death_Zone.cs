//Hayden White
//Last Update: April 27th, 2022
//This handles calling the Respawn functions of game object in the event of a player death.

using UnityEngine;

public class Death_Zone : MonoBehaviour
{
    public GameObject player;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;
    public GameObject coin5;
    public GameObject coin6;
    public GameObject instructions;

    private void OnCollisionEnter2D(Collision2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        player.GetComponent<Hayden_Respawn>().Respawn();
        coin1.GetComponent<RespawnCoin>().Respawn();
        coin2.GetComponent<RespawnCoin>().Respawn();
        coin3.GetComponent<RespawnCoin>().Respawn();
        coin4.GetComponent<RespawnCoin>().Respawn();
        coin5.GetComponent<RespawnCoin>().Respawn();
        coin6.GetComponent<RespawnCoin>().Respawn();
        instructions.GetComponent<Instructions>().Respawn();
        //These call the Respawn functions of all gameObjects if the player dies due to contacting a death zone.
    }
}