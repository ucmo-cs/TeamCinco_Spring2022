using UnityEngine;
using UnityEngine.UI;

public class TokenController : MonoBehaviour
{
    public int tokenCount = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        SetTokenText();
    }

    private void SetTokenText()
    {
        var text = GetComponent<Text>();
        text.text = tokenCount.ToString();
    }

    public bool HasTokens()
    {
        return tokenCount != 0;
    }

    public void UseToken()
    {
        tokenCount--;
        SetTokenText();
    }

    public void AddToken()
    {
        tokenCount++;
        SetTokenText();
    }
}
