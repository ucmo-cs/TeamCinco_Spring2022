using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelTransition : MonoBehaviour
{
    public string nextLevel;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != player) return;
        SceneManager.LoadScene(nextLevel);
    }
}