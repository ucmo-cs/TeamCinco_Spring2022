using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenController : MonoBehaviour
{
    public int tokenCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        SetTokenText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetTokenText()
    {
        var text = GetComponent<Text>();
        text.text = tokenCount.ToString();
    }

    public void UseToken()
    {
        tokenCount--;
        SetTokenText();
    }
}
