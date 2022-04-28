using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAttachNoRotation : MonoBehaviour
{
    public GameObject attachedTo;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = attachedTo.transform.position;
    }
}
