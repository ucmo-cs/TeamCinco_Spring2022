using UnityEngine;
using UnityEngine.UI;

public class AlexCooldownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var text = GetComponent<Text>();
        var timer = 1;
        text.text = timer.ToString();
    }
    public void UpdateTimer(int num)
    {
        if (num < 0) num = 0;
        var text = GetComponent<Text>();
        text.text = num.ToString();
    }
}