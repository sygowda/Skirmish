using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int remainingTime = 20; //Total seconds
    public Text gameTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Make sure time passes at the same rate as real time
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer.text = ("" + remainingTime); //Show the remaining time on the screen

        if(remainingTime <= 0 || GameController.instance.gameOver)
        {
            StopCoroutine("LoseTime");
            int playerWon = GameController.instance.AllChestsDestroyed();
            GameController.instance.GameOver(playerWon);
        }
    }

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            remainingTime--;
        }
    }
}
