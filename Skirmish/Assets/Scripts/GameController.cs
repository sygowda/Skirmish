using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    // Start is called before the first frame update

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AllChestsDestroyed())
            {
                GameOver();
            }
    }

    private bool AllChestsDestroyed()
    {
        GameObject[] chestsForPlayer1 = GameObject.FindGameObjectsWithTag("PlayerOneChestTag");
        GameObject[] chestsForPlayer2 = GameObject.FindGameObjectsWithTag("PlayerTwoChestTag");
        return chestsForPlayer1.Length == 0 || chestsForPlayer2.Length == 0;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }
}
