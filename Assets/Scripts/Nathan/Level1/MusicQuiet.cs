using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicQuiet : MonoBehaviour
{
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int pointOfNoReturn = 75;
        if(this.transform.position.x > pointOfNoReturn) {
            music.pitch = 1-(this.transform.position.x-pointOfNoReturn)/20;
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.gravityScale = 1-(this.transform.position.x-pointOfNoReturn)/20;
        }
    }
}
