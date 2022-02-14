using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCooldownIcon : MonoBehaviour
{
    public GameObject icon;
    void LateUpdate()
    {
        Transform target = Camera.main.transform;
        icon.transform.parent = target;
    }
}
