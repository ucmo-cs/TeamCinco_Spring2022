using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFloatingUpDisable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 10 && transform.position.x > 70) {
            GetComponent<NathanLV1Respawn>().enabled = false;
            NathanMovement movement = GetComponent<NathanMovement>();
            movement.disabled = true;
            movement.goRight();
        }
        if(transform.position.y > 200) {
            SceneManager.LoadScene("MovieTransition1");
        }
    }
}
