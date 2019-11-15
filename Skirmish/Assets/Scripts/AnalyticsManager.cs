using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class AnalyticsManager
{
    //private static string name;
    //private static int level, coin;

    //private static string name;
    //private static int level, coin;
    //private static int[] chest1 = new int[2];// for upperplayer
    //private static int[] chest2 = new int[2];// for lowerplayer
    private static string filePath = "Assets/Sources/analytics.json";

    private static int coolDownCounter;

    public static void initialize(int _coolDownCounter)
    {
        coolDownCounter = _coolDownCounter;
    }

    public static void saveAnalyticsData()
    {
        if (File.Exists(filePath))
        {
            File.WriteAllText(filePath, JsonUtility.ToJson(new Analytics(coolDownCounter)));
        }
        else
        {
            Debug.LogError("Cannot load analytics data!");
        }
    }

    public static void increaseCoolDown()
    {
        coolDownCounter++;
    }


}
