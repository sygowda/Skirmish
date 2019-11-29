using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestBButton : MonoBehaviour
{
    private TextMeshProUGUI pocket;// coin to be allocated
    private TextMeshProUGUI topChest, bottomChest;
    private Button confirmButton;
    public Button plusButton;
    public Button minusButton;

    // Start is called before the first frame update
    public void Start()
    {
        plusButton.onClick.AddListener(addCoin);
        minusButton.onClick.AddListener(minusCoin);
        pocket = GameObject.Find("Remaining").GetComponent<TextMeshProUGUI>();
        topChest = GameObject.Find("ChestA").GetComponentInChildren<TextMeshProUGUI>();
        bottomChest = GameObject.Find("ChestB").GetComponentInChildren<TextMeshProUGUI>();
        confirmButton = this.transform.parent.parent.Find("Next").GetComponent<Button>();
    }

    // Update is called once per frame
    public void addCoin()
    {
        int cash = parseCoins(pocket.text);
        if (cash >= 10)
        {
            cash -= 10;
            pocket.text = "Coins: " + cash.ToString();
            int bank = int.Parse(bottomChest.text) + 10;
            bottomChest.text = bank.ToString();
            
            if (int.Parse(topChest.text) + int.Parse(bottomChest.text) >= 100)
            {
                confirmButton.interactable = true;
            }
        }
    }


    public void minusCoin()
    {
        int bank = int.Parse(bottomChest.text);
        if (bank > 10)
        {
            bank -= 10;
            bottomChest.text = bank.ToString();

            int cash = parseCoins(pocket.text) + 10;
            pocket.text = "Coins: " + cash.ToString();
            
            if (int.Parse(topChest.text) + int.Parse(bottomChest.text) < 100)
            {
                confirmButton.interactable = false;
            }
        }
    }


    private int parseCoins(string coins)
    {
        string coin = coins.Split(':')[1];
        return int.Parse(coin);
    }
}
