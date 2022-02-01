using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject objectOfInterest;
    private Vector3 _freezePoint;

    private bool _grabbed;

    // LateUpdate is called once per frame, right before it renders.
    private void LateUpdate()
    {
        Vector2 objPos = objectOfInterest.transform.position;
        var cameraPos = gameObject.transform.position;
        if (!_grabbed && objectOfInterest.GetComponent<PlayerMovement>().IsGrabbed())
        {
            _freezePoint = gameObject.transform.position;
            _grabbed = true;
        }
        else if (_grabbed && !objectOfInterest.GetComponent<PlayerMovement>().IsGrabbed())
        {
            _grabbed = false;
        }

        if (_grabbed)
        {
            Vector2 mouseDistance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - cameraPos;
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