using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text coins;
    public Text level;
    public Text userName;
    private string filePath = "Assets/Sources/user.json";
    void Start()
    {
        loadUserData();

    }

    // Update is called once per frame
    void Update()
    {
        coins.text = UserData.getCoin().ToString();
        level.text = UserData.getLevel().ToString();
        userName.text = UserData.getName();
    }

    void loadUserData()
    {

        
        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            User loadedData = JsonUtility.FromJson<User>(dataAsJson);
            UserData.initialize(loadedData.name, loadedData.level, loadedData.coin);
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
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
