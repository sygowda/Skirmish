using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialShotsButton : MonoBehaviour
{
    private TextMeshProUGUI pocket;// coin to be allocated
    private TextMeshProUGUI specialChest;
    private Button confirmButton;
    public Button plusButton;
    public Button minusButton;

    // Start is called before the first frame update
    public void Start()
    {
        plusButton.onClick.AddListener(addCoin);
        minusButton.onClick.AddListener(minusCoin);
        pocket = GameObject.Find("Remaining").GetComponent<TextMeshProUGUI>();
        specialChest = GameObject.Find("SpecialShots").GetComponentInChildren<TextMeshProUGUI>();
        confirmButton = this.transform.parent.parent.Find("Next").GetComponent<Button>();
    }

    // Update is called once per frame
    public void addCoin()
    {
        int cash = parseCoins(pocket.text);
        if (cash >= 50)
        {
            cash -= 50;
            pocket.text = "Coins: " + cash.ToString();
            int bank = int.Parse(specialChest.text) + 1;
            specialChest.text = bank.ToString();
        }
    }


    public void minusCoin()
    {
        int bank = int.Parse(specialChest.text);
        if (bank > 0)
        {
            bank -= 1;
            specialChest.text = bank.ToString();

            int cash = parseCoins(pocket.text) + 50;
            pocket.text = "Coins: " + cash.ToString();
        }
    }


    private int parseCoins(string coins)
    {
        string coin = coins.Split(':')[1];
        return int.Parse(coin);
    }
}
