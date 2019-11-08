using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestButton : MonoBehaviour
{
    private TextMeshProUGUI pocket;// coin to be allocated
    private TextMeshProUGUI chest;// current coin in this chest
    private Button confirmButton;
    public Button plusButton;
    public Button minusButton;

    // Start is called before the first frame update
    public void Start()
    {
        plusButton.onClick.AddListener(addCoin);
        minusButton.onClick.AddListener(minusCoin);
        pocket = GameObject.Find("Remaining").GetComponent<TextMeshProUGUI>();
        chest = this.GetComponentInParent<TextMeshProUGUI>();
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
            if (cash == 0)
            {
                confirmButton.interactable = true;
            }
            int bank = int.Parse(chest.text) + 10;
            chest.text = bank.ToString();
        }
    }


    public void minusCoin()
    {
        int bank = int.Parse(chest.text);
        if (bank > 10)
        {
            bank -= 10;
            chest.text = bank.ToString();

            int cash = parseCoins(pocket.text) + 10;
            if (cash != 0)
            {
                confirmButton.interactable = false;
            }
            pocket.text = "Coins: " + cash.ToString();
        }
    }


    private int parseCoins(string coins)
    {
        string coin = coins.Split(':')[1];
        return int.Parse(coin);
    }
}
