using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexEndZone : MonoBehaviour
{
    public GameObject player;
    private Vector2 _respawnPoint = new Vector2(0, 0);

    private void Start()
    {
        _respawnPoint = player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        player.transform.position = _respawnPoint;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2();
        player.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
}
