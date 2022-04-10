using UnityEngine;
public class AlexCheckpointZone : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        Vector2 respawnPoint = player.transform.position;
        player.GetComponent<AlexRespawnScript>().SetRespawnPoint(respawnPoint);
    }
}