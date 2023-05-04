using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicScript : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    //Timer Settings
    public float timeRemaining;
    public bool timerIsRunning = false;

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

    // public float timer()
    // {
        // if (timerIsRunning)
        // {
        //     if (timeRemaining > 0)
        //     {
        //         timeRemaining -= Time.deltaTime;
        //         // Debug.Log(timeRemaining);
        //         if (timeRemaining == 0)
        //         {
        //             Debug.Log("Time has run out!");
        //             timerIsRunning = false;
        //             return timeRemaining;
        //         }
        //     }
            // else
            // {
            //     Debug.Log("Time has run out!");
            //     timeRemaining = 0;
            //     timerIsRunning = false;
            //     return timeRemaining;
            // }
        // }
        // Debug.Log(timerText.text = timeRemaining.ToString());
        // return timeRemaining;
    //     for (float i = timeRemaining; i > 0; i = i - Time.deltaTime){
    //         timeRemaining = i;
    //     }
    //     return timeRemaining;
    // }

    public string gameTimer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                // Debug.Log(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
            return timerText.text = timeRemaining.ToString();
    }

}
