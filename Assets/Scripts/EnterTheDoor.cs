using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterTheDoor : MonoBehaviour
{
    public string sceneToChangeTo;
    public Image blackScreen;
    public GameObject objectOfInterest;
    public AudioClip doorSound;

    public List<AudioSource> soundsToQuiet;

    AudioSource music;

    bool spaceClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var value = 1f - Vector2.Distance(transform.position, objectOfInterest.transform.position) / 3;
        if (value < 0) value = 0;
        if (value > 1) value = 1;
        
        if(!spaceClicked)music.volume = value > .7f ? .7f :value;
        if(value > 0) {
            foreach (AudioSource sound in soundsToQuiet) {
                sound.volume = 1-value;
            }
        }
        
        blackScreen.color = new Color(0f, 0f, 0f, value/2);
        if(value > .5f && (!spaceClicked && Input.GetButtonDown("Jump"))){
            spaceClicked = true;
            Time.timeScale = 0f;
            music.volume = 0;
            AudioSource.PlayClipAtPoint(doorSound,transform.position);
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
