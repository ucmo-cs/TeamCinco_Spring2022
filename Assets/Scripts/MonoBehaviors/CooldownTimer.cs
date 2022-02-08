using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTimer : MonoBehaviour
{
    private float _waitTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        var parent = transform.parent;

        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;

        var text = GetComponent<TextMesh>();
        text.text = string.Format("{0}", 3);
    }

    public bool UpdateTimer()
    {
        var text = GetComponent<TextMesh>();
        if (_waitTime > 0) {
            text.text = string.Format("{0}", (int)_waitTime);
            _waitTime -= Time.deltaTime;
            return false;
        } else {
            _waitTime = 3.0f;
            text.text = string.Format("{0}", (int)_waitTime);
            return true;
        }
    }
}
