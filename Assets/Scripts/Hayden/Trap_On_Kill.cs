using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_On_Kill : MonoBehaviour
{
    private bool seen = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
        //This hides the "Press Space to Jump" instructions upon starting the level.
    }

    // Update is called once per frame
    void Update()
    {
        if(seen)
        {
            this.GetComponent<Renderer>().enabled = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            seen = true;
        }
    }
}
