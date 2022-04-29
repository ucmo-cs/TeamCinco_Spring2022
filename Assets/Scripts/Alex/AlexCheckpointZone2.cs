using UnityEngine;

public class AlexCheckpointZone2 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D targetObj)
    {
        //TODO: Get a print to work, check throw count, set cpthrows to curr throwcount
        if (targetObj.gameObject != player) return;
        int throws = player.GetComponent<AlexPlayerMovement2>().throwCount;
        player.GetComponent<AlexPlayerMovement2>().SetCpThrows(throws);
        Vector2 respawnPoint = player.transform.position;
        player.GetComponent<AlexRespawnScript>().SetRespawnPoint(respawnPoint);
    }
}