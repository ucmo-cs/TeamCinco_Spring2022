using UnityEngine;

public class NathanLV1DeathZone : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        player.GetComponent<NathanLV1Respawn>().Respawn();
    }
}