using UnityEngine;

public class AlexDeathZone : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        player.GetComponent<AlexRespawnScript>().Respawn();
    }
}