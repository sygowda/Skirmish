using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTrack1_2 : MonoBehaviour
{
    public int coin;

    public void TrackCoin()
    {
        coin = int.Parse(GameObject.Find("P1Allot/Canvas/ToggleArea/ChestB/Coins").GetComponent<TextMeshProUGUI>().text);
    }
}
