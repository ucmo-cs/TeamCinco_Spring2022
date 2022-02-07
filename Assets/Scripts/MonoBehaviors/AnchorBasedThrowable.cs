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
        Debug.Log("Player Mouse Down");

        var found = false;
        foreach (var anchor in anchors)
        {
            if (!anchor.IsTouching(_player.GetComponent<Collider2D>())) continue;
            found = true;
            // TODO: move
            Debug.Log("Player Mouse Down in anchor");
        }

        if (!found)
        {
            Debug.Log("Player Mouse Down not in anchor");
        }
    }
}