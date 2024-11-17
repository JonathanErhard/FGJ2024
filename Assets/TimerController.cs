using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    private TMPro.TextMeshProUGUI TextTimer;

    public static Stopwatch Stopwatch;

    void Start()
    {
        TextTimer = GetComponent<TMPro.TextMeshProUGUI>();

        Stopwatch = new();
        Stopwatch.Start();
    }

    void Update()
    {
        TextTimer.text = Stopwatch.Elapsed.
            Minutes.ToString("00") + ":" + Stopwatch.Elapsed.Seconds.ToString("00");
    }
}
