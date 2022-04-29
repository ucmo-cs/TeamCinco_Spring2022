using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalDetector1 : MonoBehaviour
{
    public GameObject objectToDetect;
    public float detectRadius = 1.5f;
    public string sceneToLoad;
    public AudioClip portalSound;

    float distance;
    bool goInPortal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        distance = Vector2.Distance(transform.position, objectToDetect.transform.position);
        if(distance < detectRadius) {
            if(!goInPortal) AudioSource.PlayClipAtPoint(portalSound,transform.position);
            goInPortal = true;
            objectToDetect.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
    } 

    // Update is called once per frame
    void FixedUpdate()
    {
        if(goInPortal) {
            Vector3 theScale = objectToDetect.transform.localScale;
            theScale.x = distance/detectRadius;
            theScale.y = distance/detectRadius;
            objectToDetect.transform.localScale = theScale;

            objectToDetect.transform.position += (Vector3)(Vector2)((transform.position - objectToDetect.transform.position)/10f);

            if(Vector2.Distance(transform.position, objectToDetect.transform.position) < .2f)
                SceneManager.LoadScene(sceneToLoad);
        }
    }
}
