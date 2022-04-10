//Hayden White
//Last Update: April 4th, 2022
//This program handles any pop-up "instructions" that appear in my levels.

using UnityEngine;

public class Instructions : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
        //This hides the "Press Space to Jump" instructions upon starting the level.
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            Respawn();
        }
        //This checks if the player decided to manually respawn.
    }

    public void Respawn()
    {
        this.GetComponent<Renderer>().enabled = false;
        //This rehides the instructions when the player has to respawn.
    }
}
