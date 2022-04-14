using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public TokenController tokenController;
    public ColorShift image;
    public TeleportState teleportState;

    private void Start()
    {
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!tokenController.HasTokens()) return; 
        if (teleportState != TeleportState.Ready) return;
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tokenController.UseToken();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Teleporter")) return;
        teleportState = TeleportState.Ready;
        image.newColor("#A16700");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Teleporter")) return;
        teleportState = TeleportState.Inactive;
        image.newColor("#0947B4");
    }
}

public enum TeleportState {
    Ready,
    Inactive
}