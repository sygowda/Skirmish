using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int remainingTime; //Total seconds
    public Text gameTimer;
    private bool timerStart = false;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = 90;
        Time.timeScale = 1; //Make sure time passes at the same rate as real time
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.startGame == false) return;
        else if(timerStart == false)
        {
            StartCoroutine("LoseTime");
            timerStart = true;
        }
        gameTimer.text = ("" + remainingTime); //Show the remaining time on the screen

        if(/*remainingTime <= 0 || */GameController.instance.gameOver)
        {
            StopCoroutine("LoseTime");
            GameController.instance.GameOver();
        }
    }

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            remainingTime--;
            AnalyticsManager.setTotalGameDuration(remainingTime);
        }
    }
}
