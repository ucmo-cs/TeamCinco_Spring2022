using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTokenPickup : MonoBehaviour
{
    public TokenController _tokenController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Coin")) return;
        _tokenController.AddToken();
        Destroy(other.gameObject);
    }
}
