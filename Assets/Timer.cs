using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 600;
    public bool timerIsRunning = true;
    public TextMeshProUGUI value;

    void Update() {
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            }
            else{
                EndOfTimer();
            }
            DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay) {
        timeToDisplay += 1; // чтобы избежать некорректного отображения при нулевом значении
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        value.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void EndOfTimer()
    {
        
    }
}

}
