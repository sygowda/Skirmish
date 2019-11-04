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
    public ArrayList availableBrickPositions;
    public GameObject endMenu;

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
        availableBrickPositions = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        int playerWon = AllChestsDestroyed();
        if (playerWon >= 0)
            {
                GameOver(playerWon);
            }
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

        if(player == PLAYER_1)
        {
            player1Text.text = ("You WIN 200 coins!");
            player2Text.text = ("You LOSE 100 coins!"); 
        }
        else if (player == PLAYER_2)
        {
            player2Text.text = ("You WIN 200 coins!");
            player1Text.text = ("You LOSE 100 coins!");
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

        if (chestsForPlayer1.Length == chestsForPlayer2.Length)
        {
            drawText.SetActive(true);
        }
        else if (chestsForPlayer1.Length > chestsForPlayer2.Length)
        {
            player1Text.text = ("You WIN!");
            player2Text.text = ("You LOSE!");
        }
        else
        {
            player2Text.text = ("You WIN!");
            player1Text.text = ("You LOSE!");
        }

        player1Text.gameObject.SetActive(true);
        player2Text.gameObject.SetActive(true);
        endMenu.SetActive(true);
    }
}
