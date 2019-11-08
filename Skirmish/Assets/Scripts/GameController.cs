using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    private const int PLAYER_1 = 1;
    private const int PLAYER_2 = 2;
    private const int DRAW = 0;
    public static GameController instance;
    public GameObject drawText;
    public Text player1Text;
    public Text player2Text;
    public bool gameOver = false;
    public GameObject endMenu;
    public Text startCountDown;
    public bool startGame = false;
    public int p1_total;
    public int p2_total;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        p1_total = UserData.getChest1(0) + UserData.getChest1(1);
        p2_total = UserData.getChest2(0) + UserData.getChest2(1);
        Debug.Log(p1_total);
        Debug.Log(p2_total);
        StartCoroutine("gameStartCountdown");
    }

    // Update is called once per frame
    void Update()
    {
        if(startGame) startCountDown.gameObject.SetActive(false);
        int playerWon = AllChestsDestroyed();
        if (playerWon >= 0) GameOver(playerWon);
    }

    IEnumerator gameStartCountdown()
    {
        startCountDown.text = "3";
        yield return new WaitForSeconds(1);
        startCountDown.text = "2";
        yield return new WaitForSeconds(1);
        startCountDown.text = "1";
        yield return new WaitForSeconds(1);
        startCountDown.text = "GO!";
        yield return new WaitForSeconds(1);
        startGame = true;
    }

    public int AllChestsDestroyed()
    {
        GameObject[] chestsForPlayer1 = GameObject.FindGameObjectsWithTag("PlayerOneChestTag");
        GameObject[] chestsForPlayer2 = GameObject.FindGameObjectsWithTag("PlayerTwoChestTag");
        if (chestsForPlayer1.Length == 0 && chestsForPlayer2.Length > 0) return PLAYER_2;
        if (chestsForPlayer2.Length == 0 && chestsForPlayer1.Length > 0) return PLAYER_1;
        return -1;
    }

    public void GameOver(int player)
    {
        gameOver = true;
        int reward = p1_total;

        if (player == PLAYER_1)
        {
            player1Text.text = ("You WIN" + (p1_total - 100) + " coins!");
            player2Text.text = ("You LOSE" + (100 - p2_total) + " coins!");
        }
        else if (player == PLAYER_2)
        {
            player2Text.text = ("You WIN" + (p2_total - 100) + " coins!");
            player1Text.text = ("You LOSE" + (100 - p1_total) + " coins!");

        }
        else
        {
            drawText.SetActive(true);
            endMenu.SetActive(true);
        }

        player1Text.gameObject.SetActive(true);
        player2Text.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        gameOver = true;

        GameObject[] chestsForPlayer1 = GameObject.FindGameObjectsWithTag("PlayerOneChestTag");
        GameObject[] chestsForPlayer2 = GameObject.FindGameObjectsWithTag("PlayerTwoChestTag");

        if (p1_total == p2_total)
        {
            drawText.SetActive(true);
        }
        else if (p1_total > p2_total)
        {
            player1Text.text = ("You WIN" + (p1_total - 100) + " coins!");
            player2Text.text = ("You LOSE" + (100 - p2_total) + " coins!");
        }
        else
        {
            player2Text.text = ("You WIN" + (p2_total - 100) + " coins!");
            player1Text.text = ("You LOSE" + (100 - p1_total) + " coins!");
        }

        player1Text.gameObject.SetActive(true);
        player2Text.gameObject.SetActive(true);
        endMenu.SetActive(true);
    }
}
