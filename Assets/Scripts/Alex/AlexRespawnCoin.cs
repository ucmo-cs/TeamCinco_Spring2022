using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AlexRespawnCoin : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        player.GetComponent<AlexPlayerMovement2>().UpdateThrows();
    }

    public void Respawn()
    {
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}