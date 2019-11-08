using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class P2AllotManager : MonoBehaviour
{
    private Button nextButton;
    // Start is called before the first frame update
    void Start()
    {
        nextButton = GameObject.Find("Next").GetComponent<Button>();
        nextButton.interactable = false;
        AutoAlloc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(3);
    }

    void AutoAlloc()
    {
        TextMeshProUGUI remainingGO = GameObject.Find("Remaining").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI upperChest = GameObject.Find("ChestA").GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI lowerChest = GameObject.Find("ChestB").GetComponentInChildren<TextMeshProUGUI>();

        int availableCoins = int.Parse(remainingGO.text.Split(':')[1]);
        int randCoins = Random.Range(0, availableCoins / 10);
        upperChest.text = (int.Parse(upperChest.text) + randCoins * 10).ToString();
        lowerChest.text = (int.Parse(lowerChest.text) + availableCoins - randCoins * 10).ToString();
        remainingGO.text = "Coins: 0";
        nextButton.interactable = true;
    }
}
