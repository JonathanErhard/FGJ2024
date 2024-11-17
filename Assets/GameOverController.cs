using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public static bool Success;

    public TMPro.TextMeshProUGUI TextGameOver;
    public TMPro.TextMeshProUGUI TextTimer;

    private float _timer = 3;

    void Start()
    {
        TextTimer.text = TimerController.Stopwatch.Elapsed.
            Minutes.ToString("00") + ":" + TimerController.Stopwatch.Elapsed.Seconds.ToString("00");

        TextGameOver.text = Success ? "You did it!" : "You lost!";
    }

    void Update()
    {
        if (_timer >= 0)
            _timer -= Time.deltaTime;
        else if(Input.anyKeyDown)
            SceneManager.LoadScene("PlayerScene");
    }
}
