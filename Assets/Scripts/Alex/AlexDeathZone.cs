using UnityEngine;

public class AlexDeathZone : MonoBehaviour
{
    public GameObject player;
    public AlexRespawnCoin coin;
    public AlexRespawnCoin coin2;
    private void OnCollisionEnter2D(Collision2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        player.GetComponent<AlexRespawnScript>().Respawn();
        player.GetComponent<AlexPlayerMovement2>().ResetThrows();
        coin.Respawn();
        coin2.Respawn();
    }
}