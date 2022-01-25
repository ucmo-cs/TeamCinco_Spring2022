using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource mainMenuMusic;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMenuMusic.time >= 12.3879) mainMenu.SetActive(true);
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
}
