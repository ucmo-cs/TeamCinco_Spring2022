using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vsas : MonoBehaviour
{
    public AudioSource music;
    public GameObject objectOfInterest;
    private Vector2 pos;
    private float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (i > Mathf.PI) i = 0;
        var value = 1.2f-Vector2.Distance(this.transform.position, objectOfInterest.transform.position)/10;
        if (value < 0) value = 0;
        if (value > 1) value = 1;
        music.volume = value;
        this.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, value);
        i += Time.deltaTime*1.5f;
        this.transform.position = pos + new Vector2(0, Mathf.Sin(i));
    }
}
