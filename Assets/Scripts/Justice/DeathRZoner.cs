using UnityEngine;

public class DeathRZoner : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        player.GetComponent<RespawnScriptToken>().Respawn();
    }
}