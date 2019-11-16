using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class AnalyticsManager
{

    private static string filePath = "Assets/Sources/coolDownAnalytics.csv";

    private static int[] coolDownCounter;

    public static void initialize(int _coolDownCounter1, int _coolDownCounter2)
    {
        coolDownCounter = new int[2];
        coolDownCounter[0] = _coolDownCounter1;
        coolDownCounter[1] = _coolDownCounter2;
    }

    public static void saveAnalyticsData()
    {
        if (!File.Exists(filePath))
        {
            string cooldownHeader = "Player" + "," + "CoolDownCount" + System.Environment.NewLine;
            File.WriteAllText(filePath, cooldownHeader);
        }

        string player1CoolDown = "playerOne" + "," + coolDownCounter[0] + System.Environment.NewLine;
        File.AppendAllText(filePath, player1CoolDown);
        string player2CoolDown = "playerTwo" + "," + coolDownCounter[1] + System.Environment.NewLine;
        File.AppendAllText(filePath, player2CoolDown);
    }

    public static void increaseCoolDownCount(int player)
    {
        coolDownCounter[player]++;
    }


}
