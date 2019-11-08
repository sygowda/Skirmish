using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class P1AllotManager : MonoBehaviour
{
    private Button nextButton;
    private TextMeshProUGUI silverChest;
    private TextMeshProUGUI goldChest;
    // Start is called before the first frame update
    void Start()
    {
        nextButton = GameObject.Find("Next").GetComponent<Button>();
        silverChest = GameObject.Find("ChestA").GetComponentInChildren<TextMeshProUGUI>();
        goldChest = GameObject.Find("ChestB").GetComponentInChildren<TextMeshProUGUI>();

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
        SceneManager.LoadScene(2);
    }

    void AutoAlloc()
    {
        TextMeshProUGUI remainingGO = GameObject.Find("Remaining").GetComponent<TextMeshProUGUI>();

        int availableCoins = int.Parse(remainingGO.text.Split(':')[1]);
        int randCoins = Random.Range(0, availableCoins / 10);
        silverChest.text = (int.Parse(silverChest.text) + randCoins * 10).ToString();
        goldChest.text = (int.Parse(goldChest.text) + availableCoins - randCoins * 10).ToString();
        remainingGO.text = "Coins: 0";
        nextButton.interactable = true;
    }

    void Save(int v, int i)
    {
        UserData.setChest1(v, i);
    }
}
