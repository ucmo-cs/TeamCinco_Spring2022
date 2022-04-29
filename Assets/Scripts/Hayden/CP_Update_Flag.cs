using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP_Update_Flag : MonoBehaviour
{
    private Animator flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        flag.Play("Checkpoint");
    }
}
