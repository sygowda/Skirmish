using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class button_minus : MonoBehaviour
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
        int alloted = int.Parse(chestA.text);
        if (alloted > 10)
        {
            int newAlloted = alloted - 10;
            chestA.text = newAlloted.ToString();
            int newRemaining = parseCoins(remainingGO.text) + 10;
            if (newRemaining > 0)
            {
                confirmButton.interactable = false;
            }
            remainingGO.text = "Coins: " + newRemaining.ToString();
        }
    }

    private int parseCoins(string coins)
    {
        string coin = coins.Split(':')[1];
        return int.Parse(coin);
    }
}
