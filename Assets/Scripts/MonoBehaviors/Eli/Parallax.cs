using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _cam.transform.position.y, transform.position.z);
    }
}
