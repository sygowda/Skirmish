using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class button_plus : MonoBehaviour
{
    private TextMeshProUGUI remainingGO;
    private TextMeshProUGUI chestA;
    private Button confirmButton;

    // Start is called before the first frame update
    public void Start()
    { 
        remainingGO = GameObject.Find("Remaining").GetComponent<TextMeshProUGUI>();
        chestA = this.GetComponentInParent<TextMeshProUGUI>();
        confirmButton = this.transform.parent.parent.Find("Next").GetComponent<Button>();
        confirmButton.interactable = false;
    }

    // Update is called once per frame
    public void Click()
    {
        int remaining = parseCoins(remainingGO.text);
        if (remaining >= 10)
        {
            int newRemaining = remaining - 10;
            remainingGO.text = "Coins: " + newRemaining.ToString();
            if (newRemaining == 0)
            {
                confirmButton.interactable = true;
            }
            int newChestA = int.Parse(chestA.text) + 10;
            chestA.text = newChestA.ToString();
            UserData.setChest1_1(newChestA);
        }
    }

    private int parseCoins(string coins)
    {
        string coin = coins.Split(':')[1];
        return int.Parse(coin);
    }
}
