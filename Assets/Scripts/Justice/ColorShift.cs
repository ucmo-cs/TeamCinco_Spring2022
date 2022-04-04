using UnityEngine;
using UnityEngine.UI;
using  System;

public class ColorShift: MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Start()
    {  
    }

    private void SetColor(Color color)
    {
        var image = GetComponent<Image>();
        var child = image.GetComponentInChildren<Text>();
        image.color = color;
        child.color = color;
    }

    public void newColor(String Hex) {
        Color color;
        ColorUtility.TryParseHtmlString(Hex, out color);
        SetColor(color);
    }
}
