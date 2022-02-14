using UnityEngine;

public class vsas : MonoBehaviour
{
    public AudioSource music;
    public AudioSource music2;
    public GameObject objectOfInterest;
    private Vector2 _pos;

    private float _i;

    // Start is called before the first frame update
    private void Start()
    {
        _pos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_i > Mathf.PI) _i = 0;
        var value = 1.2f - Vector2.Distance(transform.position, objectOfInterest.transform.position) / 10;
        if (value < 0) value = 0;
        if (value > 1) value = 1;
        music.volume = value;
        music2.volume = 1-(value*2);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, value);
        _i += Time.deltaTime * 1.5f;
        transform.position = _pos + new Vector2(0, Mathf.Sin(_i));
    }
}