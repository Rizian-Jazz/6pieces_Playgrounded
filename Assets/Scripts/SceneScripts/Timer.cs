using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 10f;
    public bool isRunning = false;
    void Update()
    {
        if (isRunning == true)
        {
            Debug.Log("Timer is running. Time left: " + time);
            time -= Time.deltaTime;
        }
        if (isRunning == false)
        {
            time = 10f;
            Debug.Log("Timer is not running.");
        }
        
    }
}
