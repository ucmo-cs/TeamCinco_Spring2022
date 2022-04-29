using UnityEngine;
public class Checkpoint : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        Vector2 _respawnPoint = player.transform.position;
        player.GetComponent<Hayden_Respawn>().SetRespawnPoint(_respawnPoint);
        this.GetComponent<Collider2D>().enabled = false;
    }
}