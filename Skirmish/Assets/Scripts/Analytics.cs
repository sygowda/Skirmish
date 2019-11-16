using System;
using UnityEngine.UI;

public class Analytics
{
    public string player;
    public int coolDownCounter;

    public Analytics(string _player, int _coolDownCounter)
    {
        player = _player;
        coolDownCounter = _coolDownCounter;
    }
}
