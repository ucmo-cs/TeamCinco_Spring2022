using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length, _startPos;
    private Camera _cam;
    public float parallaxEffect;

    private void Start()
    {
        _cam = Camera.main;
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        var temp = _cam.transform.position.x * (1 - parallaxEffect);
        var distance = _cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);

        if (temp > _startPos + _length) _startPos += _length;
        else if (temp < _startPos - _length) _startPos -= _length;
    }
}
