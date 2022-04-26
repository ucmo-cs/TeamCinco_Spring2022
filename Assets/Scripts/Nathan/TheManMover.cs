using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheManMover : MonoBehaviour
{
    public TheManController controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    int musicVelocity = 0;
    public AudioSource music;
    public AudioSource wind;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //if(horizontalMove < 0) horizontalMove = 0;

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
        if (transform.position.y < -60) //death zone dead become daed
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        if(horizontalMove > 0 && musicVelocity < 20) {
            musicVelocity++;
        }
        if(horizontalMove <= 0 && musicVelocity > 0) {
            musicVelocity--;
        }
        music.pitch = musicVelocity/20f;
        wind.volume = 1-musicVelocity/20f;
    }
}
