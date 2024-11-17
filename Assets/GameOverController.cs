using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public static bool Success;

    public TMPro.TextMeshProUGUI TextGameOver;
    public TMPro.TextMeshProUGUI TextTimer;

    void Start()
    {
        TextTimer.text = TimerController.Stopwatch.Elapsed.
            Minutes.ToString("00") + ":" + TimerController.Stopwatch.Elapsed.Seconds.ToString("00");

        TextGameOver.text = Success ? "You did it!" : "You lost!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
