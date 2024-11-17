using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioController.Instance.PlayAmbientSound();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWinLooseState();
    }

    public void CheckWinLooseState()
    {
        if(PlayerController.Instance.Health <= 0 ||
            Alien.Instance.Hunger <= 0)
        {
            TimerController.Stopwatch.Stop();
            GameOverController.Success = false;
            SceneManager.LoadScene("GameOver");
        }

        if(TextProcessor.Instance.AllKeysSet)
        {
            TimerController.Stopwatch.Stop();
            GameOverController.Success = true;
            SceneManager.LoadScene("GameOver");
        }
    }
}
