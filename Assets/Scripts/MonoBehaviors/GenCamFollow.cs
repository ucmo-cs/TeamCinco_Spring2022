using UnityEngine;

public class GenCamFollow : MonoBehaviour
{
    public GameObject objectOfInterest;

    // LateUpdate is called once per frame, right before it renders.
    private void LateUpdate()
    {
        Vector2 objPos = objectOfInterest.transform.position;
        var cameraPos = gameObject.transform.position;
     
        var xDif = (objPos.x - cameraPos.x) * Time.deltaTime * 10;
        var yDif = (objPos.y - cameraPos.y) * Time.deltaTime * 10;
        gameObject.transform.position = new Vector3(cameraPos.x + xDif, cameraPos.y + yDif, cameraPos.z);
    }
}