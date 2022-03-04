using UnityEngine;

public class GenCamFollow : MonoBehaviour
{
    public GameObject objectOfInterest;
    private Vector3 _freezePoint;


    // LateUpdate is called once per frame, right before it renders.
    private void LateUpdate()
    {
        Vector2 objPos = objectOfInterest.transform.position;
        var cameraPos = gameObject.transform.position;

            // Vector2 mouseDistance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - cameraPos;
            // var targetX = _freezePoint.x + mouseDistance.x / 10;
            // var targetY = _freezePoint.y + mouseDistance.y / 10;
            // var xDif = (targetX - cameraPos.x) * Time.deltaTime * 10;
            // var yDif = (targetY - cameraPos.y) * Time.deltaTime * 10;
            // gameObject.transform.position = new Vector3(cameraPos.x + xDif, cameraPos.y + yDif, cameraPos.z);
      
        var xDif = (objPos.x - cameraPos.x) * Time.deltaTime * 10;
        var yDif = (objPos.y - cameraPos.y) * Time.deltaTime * 10;
        gameObject.transform.position = new Vector3(cameraPos.x + xDif, cameraPos.y + yDif, cameraPos.z);
        
    }
}