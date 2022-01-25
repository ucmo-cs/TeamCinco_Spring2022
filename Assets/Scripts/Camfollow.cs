using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject objectOfInterest;
    private Vector3 freezePoint;
    private bool grabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // LateUpdate is called once per frame, right before it renders.
    void LateUpdate() {
        Vector2 objPos = objectOfInterest.transform.position;
        Vector3 cameraPos = this.gameObject.transform.position;
        if(!grabbed && objectOfInterest.GetComponent<PlayerMovement>().isGrabbed()) {
            freezePoint = this.gameObject.transform.position;
            grabbed = true;
        } else if (grabbed && !objectOfInterest.GetComponent<PlayerMovement>().isGrabbed()) {
            grabbed = false;
        }
        if(grabbed) {
            Vector2 mouseDistance = Camera.main.ScreenToWorldPoint(Input.mousePosition)-cameraPos;
            float targetX = freezePoint.x + mouseDistance.x/10;
            float targetY = freezePoint.y + mouseDistance.y/10;
            float xDif = (targetX - cameraPos.x)*Time.deltaTime*10;
            float yDif = (targetY - cameraPos.y)*Time.deltaTime*10;
            this.gameObject.transform.position = new Vector3(cameraPos.x + xDif, cameraPos.y + yDif, cameraPos.z);
        } else {
            float xDif = (objPos.x - cameraPos.x)*Time.deltaTime*10;
            float yDif = (objPos.y - cameraPos.y)*Time.deltaTime*10;
            this.gameObject.transform.position = new Vector3(cameraPos.x + xDif, cameraPos.y + yDif, cameraPos.z);
        }
    }
}
