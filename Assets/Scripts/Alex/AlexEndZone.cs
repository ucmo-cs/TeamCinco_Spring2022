using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlexEndZone : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    private Vector2 _respawnPoint = new Vector2(0, 0);

    private void Start()
    {
        _respawnPoint = player.transform.position;
        anim = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D targetObj)
    {
        if (targetObj.gameObject != player) return;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger("EndZone");
        StartCoroutine(WaitCoroutine());
    }
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1.75f);
        SceneManager.LoadScene("Scenes/Alex/Level 2");
    }
}
