using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool PAUSED = false;
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (PAUSED) Resume();
            else Pause();
        }
    }

    void Pause() {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        PAUSED = true;
    }

    public void Resume() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        PAUSED = false;
    }

    public void Exit() {
        Application.Quit();
    }

    public void Options() {

    }
}
