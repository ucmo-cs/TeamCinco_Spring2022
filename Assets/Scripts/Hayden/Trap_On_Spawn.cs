using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_On_Spawn : MonoBehaviour
{
    private bool hit = false;

    public SpriteRenderer curSprite;

    public Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            ChangeSprite();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            hit = true;
        }
    }

    void ChangeSprite()
    {
        curSprite.sprite = newSprite;
    }
}
