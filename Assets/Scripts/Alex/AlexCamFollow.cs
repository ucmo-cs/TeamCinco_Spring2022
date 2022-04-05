using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCamFollow : MonoBehaviour
{
    public GameObject objectOfInterest;
    private Vector3 _freezePoint;

    private bool _grabbed;
    private Camera cam;

    public void Start()
    {
        cam = Camera.main;
    }

    // LateUpdate is called once per frame, right before it renders.
    private void LateUpdate()
    {
        Vector2 objPos = objectOfInterest.transform.position;
        var cameraPos = gameObject.transform.position;
        bool _isGrabbed = objectOfInterest.GetComponent<AlexPlayerMovement>().IsGrabbed();
        //Saving for Level 2
        // bool _isWaiting = objectOfInterest.GetComponent<AlexPlayerMovement>().IsWaiting();
        // if (!_grabbed && _isGrabbed && _isWaiting)
        if (!_grabbed)
        {
            _freezePoint = gameObject.transform.position;
            _grabbed = true;
        }
        //Saving for Level 2
        // else if (_grabbed && !_isGrabbed && !_isWaiting)
        else if (_grabbed)
        {
            _grabbed = false;
        }

        if (_grabbed)
        {
            Vector2 mouseDistance = cam.ScreenToWorldPoint(Input.mousePosition) - cameraPos;
            var targetX = _freezePoint.x + mouseDistance.x / 10;
            var targetY = _freezePoint.y + mouseDistance.y / 10;
            var xDif = (targetX - cameraPos.x) * Time.deltaTime * 10;
            var yDif = (targetY - cameraPos.y) * Time.deltaTime * 10;
            gameObject.transform.position = new Vector3(cameraPos.x + xDif, cameraPos.y + yDif, cameraPos.z);
        }
        else
        {
            var xDif = (objPos.x - cameraPos.x) * Time.deltaTime * 10;
            var yDif = (objPos.y - cameraPos.y) * Time.deltaTime * 10;
            gameObject.transform.position = new Vector3(cameraPos.x + xDif, cameraPos.y + yDif, cameraPos.z);
        }
    }
}
