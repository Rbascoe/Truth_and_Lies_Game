using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    //Timer Settings
    public float timeRemaining;
    public bool timerIsRunning = false;

    public GameObject gameOverScreen;
    //public bool hasLimit;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 35f;
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer();
    }


        public float gameTimer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
               timeRemaining -= Time.deltaTime;
                // Debug.Log(timeRemaining);
            }
            else if (timeRemaining <= 0)
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        timerText.text = timeRemaining.ToString();
        return timeRemaining;
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).buildIndex);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

}
