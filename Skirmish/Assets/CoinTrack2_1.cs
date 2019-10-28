using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrack2_1 : MonoBehaviour
{
    public int coin;

    public void TrackCoin()
    {
        coin = int.Parse(GameObject.Find("P2Allot/Canvas/ToggleArea/ChestA/Coins").GetComponent<TextMeshProUGUI>().text);
    }
}
