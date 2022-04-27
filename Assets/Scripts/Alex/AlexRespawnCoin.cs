using UnityEngine;

public class AlexRespawnCoin : MonoBehaviour
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