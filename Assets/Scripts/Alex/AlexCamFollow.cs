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
        //Saving for Level 2
        // bool _isGrabbed = objectOfInterest.GetComponent<AlexPlayerMovement>().IsGrabbed();
        // bool _isWaiting = objectOfInterest.GetComponent<AlexPlayerMovement>().IsWaiting();
        // if (!_grabbed && _isGrabbed && _isWaiting)
        // else if (_grabbed && !_isGrabbed && !_isWaiting)
        if (!_grabbed) _freezePoint = gameObject.transform.position;
        _grabbed = !_grabbed;
        
        Vector2 mouseDistance = cam.ScreenToWorldPoint(Input.mousePosition) - cameraPos;
        var targetX = _grabbed ? _freezePoint.x + mouseDistance.x / 10 : objPos.x;
        var targetY = _grabbed ? _freezePoint.y + mouseDistance.y / 10 : objPos.y;
        var xDif = (targetX - cameraPos.x) * Time.deltaTime * 10;
        var yDif = (targetY - cameraPos.y) * Time.deltaTime * 10;
        gameObject.transform.position = new Vector3(cameraPos.x + xDif, cameraPos.y + yDif, cameraPos.z);
    }
}
