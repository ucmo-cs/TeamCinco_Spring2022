using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        
    }

    public void PlayGame() {
        SceneManager.LoadScene(2);
    }
}
