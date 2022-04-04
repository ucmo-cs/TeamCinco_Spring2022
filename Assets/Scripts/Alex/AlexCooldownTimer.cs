using UnityEngine;
using UnityEngine.UI;

public class AlexCooldownTimer : MonoBehaviour
{
    private float totalDistance = 0.0f;
    private int timer = 5;
    private static float distanceGoal = 200.0f;
    private float nextMilestone = distanceGoal / 5;
    public bool _doneWaiting = true;

    // Start is called before the first frame update
    private void Start()
    {
        var text = GetComponent<Text>();
        text.text = timer.ToString();
    }

    public bool UpdateTimer(float distanceThisFrame)
    {
        var text = GetComponent<Text>();
        if (totalDistance < distanceGoal)
        {
            totalDistance += distanceThisFrame;
            Debug.Log(totalDistance);
            if (totalDistance > nextMilestone)
            {
                nextMilestone += distanceGoal / 5;
                timer -= 1;
            }
            text.text = timer.ToString();
            return false;
        }

        totalDistance = 0.0f;
        timer = 5;
        text.text = timer.ToString();
        return true;
    }
}