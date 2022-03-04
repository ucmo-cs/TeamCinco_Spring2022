using UnityEngine;

public class Destructable : MonoBehaviour
{
    public PlayerDash player;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.rigidbody.transform != player.transform) return;
        Debug.Log("Collision with player");
        Destroy(gameObject);
    }
}