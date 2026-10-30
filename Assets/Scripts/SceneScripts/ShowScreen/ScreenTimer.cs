using UnityEngine;
using TMPro;

public class ScreenTimer : MonoBehaviour
{
    public float totalSeconds = 0f;
    public int minutes, seconds;
    public TextMeshProUGUI timerText;
    void Update()
    {
        totalSeconds += Time.deltaTime;
        minutes = Mathf.FloorToInt(totalSeconds / 60f);
        seconds = Mathf.FloorToInt(totalSeconds % 60f);
        timerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }
}
