using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public Rigidbody2D player;

    private bool grabbed;

    private void Start()
    {
        Debug.Log("Start");
    }

    private void OnMouseDown()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!(Vector2.Distance(player.position, mousePosition) < .5)) return;
        Debug.Log("Click near player");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject != player) return;
        if (Input.GetMouseButton(0))
        {
            // Input.get
        }
    }
}