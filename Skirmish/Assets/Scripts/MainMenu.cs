using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text coins;
    public Text level;
    public Text userName;
    void Start()
    {
        UserData.initialize("Skr",1,10);
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = UserData.getCoin().ToString();
        level.text = UserData.getLevel().ToString();
        userName.text = UserData.getName();
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        

    }

    public void VisitStore()
    {
        SceneManager.LoadScene(4);

    }
}
