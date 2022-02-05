using UnityEngine;

public class AnchorBasedThrowable : MonoBehaviour
{
    public Collider2D[] anchors;

    private Rigidbody2D _player;

    // Start is called before the first frame update
    private void Start()
    {
        _player = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        foreach (var anchor in anchors)
        {
            if (!anchor.IsTouching(_player.GetComponent<Collider2D>())) continue;
            // TODO: move
            Debug.Log("Player Mouse Down in anchor");
        }
    }
}