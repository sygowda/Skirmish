using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class P2AllotManager : MonoBehaviour
{
    private Button nextButton;
    private TextMeshProUGUI silverChest;
    private TextMeshProUGUI goldChest;
    private TextMeshProUGUI specialShots;
    // Start is called before the first frame update
    void Start()
    {
        nextButton = GameObject.Find("Next").GetComponent<Button>();
        silverChest = GameObject.Find("ChestA").GetComponentInChildren<TextMeshProUGUI>();
        goldChest = GameObject.Find("ChestB").GetComponentInChildren<TextMeshProUGUI>();
        specialShots = GameObject.Find("SpecialShots").GetComponentInChildren<TextMeshProUGUI>();

        nextButton.interactable = false;
        AutoAlloc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        Save(int.Parse(silverChest.text), 0);
        Save(int.Parse(goldChest.text), 1);
        Save(int.Parse(specialShots.text), 2);
        SceneManager.LoadScene(3);
    }

    void AutoAlloc()
    {
        TextMeshProUGUI remainingGO = GameObject.Find("Remaining").GetComponent<TextMeshProUGUI>();

        int allocCoins = int.Parse(remainingGO.text.Split(':')[1]);
        int availableCoins = 80;
        int randCoins = Random.Range(0, availableCoins / 10);
        silverChest.text = (int.Parse(silverChest.text) + randCoins * 10).ToString();
        goldChest.text = (int.Parse(goldChest.text) + availableCoins - randCoins * 10).ToString();
        remainingGO.text = "Coins: " + (allocCoins - availableCoins).ToString();
        nextButton.interactable = true;
    }

    void Save(int v, int i)
    {
        UserData.setChest1(v, i); // upper player
    }
}
