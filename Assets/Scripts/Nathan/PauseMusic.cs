using UnityEngine;

public class PauseMusic : MonoBehaviour
{
    // This script also keeps track of pause, so that I knows when it changed.
    private bool pause;

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.PAUSED != pause) {
            pause = !pause;
            if(pause) GetComponent<AudioSource>().Pause();
            else GetComponent<AudioSource>().Play();
        }
    }
}
