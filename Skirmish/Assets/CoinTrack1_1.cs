using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTrack1_1 : MonoBehaviour
{
    public int coin;

    public void TrackCoin()
    {
        coin = int.Parse(GameObject.Find("P1Allot/Canvas/ToggleArea/ChestA/Coins").GetComponent<TextMeshProUGUI>().text);
    }
}
