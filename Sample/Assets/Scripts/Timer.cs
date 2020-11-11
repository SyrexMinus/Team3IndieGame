using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Treasure treasure;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public Text victory;
    public Text lost;
    public Button NextLevel;
    public Button ReplayLevel;
    public Button PauseButton;
    private void Start()
    {
        // Starts the timer automatically
        Time.timeScale = 0f;

        treasure = GameObject.FindObjectOfType<Treasure>();
        timerIsRunning = true;
        victory.enabled = false;
        lost.enabled = false;
        GetComponent<enemy_sp>().enabled = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (treasure.currentLifes == 0)
            {
                LoseGame();
            }
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                WinGame();
            }
        }
    }

    // stop game, button restart
    public void LoseGame()
    {
        timerIsRunning = false;
        lost.enabled = true;

        // disable throwing
        GameObject.Find("ThrowingZone").GetComponent<KnifeControllingScript>().DisableThrowing();
        // stop time and show replay button
        ReplayLevel.gameObject.SetActive(true);
        lost.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    // stop game, button next level
    public void WinGame()
    {
        timerIsRunning = false;
        victory.enabled = true;

        // disable throwing
        GameObject.Find("ThrowingZone").GetComponent<KnifeControllingScript>().DisableThrowing();
        // stop time and show next level button
        NextLevel.gameObject.SetActive(true);
        victory.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    // displaying left time
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}