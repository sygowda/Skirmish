using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class ChestAllocateAnalytics
{
    private static int[] chestp1;
    private static int[] chestp2;
    private static int timer;
    private static string allocateTrackerPath = "Assets/Sources/allocateAnalytics.csv";

    public static void initializeAllocationTrackerp1(int c1,int c2)
    {
        chestp1 = new int[2];
        chestp1[0] = c1;
        chestp1[1] = c2;
    }

    public static void initializeAllocationTrackerp2(int c1, int c2)
    {
        chestp2 = new int[2];
        chestp2[0] = c1;
        chestp2[1] = c2;
    }

    public static void saveChestData()
    {
        if (!File.Exists(allocateTrackerPath))
        {
            string chestHeader = "Time" + "," + "Player" + ", " + "Chest 1(Silver)" + ", " + "Chest 2(Gold)" + Environment.NewLine;
            File.WriteAllText(allocateTrackerPath, chestHeader);
        }

        string player1 = System.DateTime.Now + "," + "Player1" + "," + chestp1[0] + "," + chestp1[1] + Environment.NewLine;
        File.AppendAllText(allocateTrackerPath, player1);

        string player2 = System.DateTime.Now + "," + "Player2" + "," + chestp2[0] + "," + chestp2[1] + Environment.NewLine;
        File.AppendAllText(allocateTrackerPath, player2);

        
    }
}
