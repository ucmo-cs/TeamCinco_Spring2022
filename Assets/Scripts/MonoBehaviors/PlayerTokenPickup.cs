using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTokenPickup : MonoBehaviour
{
    private int tokens = 0;

    public TextMeshProUGUI textTokens;
    //This is used to show the number of jumps a player has on screen.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Coin")) return;
        tokens++;
        //This adds one to the players jump counter.

        textTokens.text = tokens.ToString();
        //This visually shows the players' jump count.

        Destroy(other.gameObject);
        //This removes the token from the game.
    }
}
