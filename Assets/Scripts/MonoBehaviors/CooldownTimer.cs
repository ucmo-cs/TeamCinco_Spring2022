using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    private float _waitTime = 3.0f;

    // Start is called before the first frame update
    private void Start()
    {
        var text = GetComponent<Text>();
        text.text = "3";
    }

    public bool UpdateTimer()
    {
        var text = GetComponent<Text>();
        if (_waitTime > 0)
        {
            text.text = ((int) _waitTime).ToString();
            _waitTime -= Time.deltaTime;
            return false;
        }

        _waitTime = 3.0f;
        text.text = "3";
        return true;
    }
}