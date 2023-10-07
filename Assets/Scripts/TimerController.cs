using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float totalTime = 180.0f;

    private float currentTime;

    private bool timerExpired = false;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (!timerExpired)
        {
            // Timer has reached zero.
            currentTime = 0f; // Ensure the timer doesn't go below 0.
            UpdateTimerDisplay();
            timerText.color = Color.red; // Change text color to red.

            // Add your timer expiration logic here.
            // For example, you can end the game or perform any other actions.

            timerExpired = true;
        }

    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
