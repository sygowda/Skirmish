using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTrack2_2 : MonoBehaviour
{
    public int coin;

    public void TrackCoin()
    {
        coin = int.Parse(GameObject.Find("P2Allot/Canvas/ToggleArea/ChestB/Coins").GetComponent<TextMeshProUGUI>().text);
    }
}
