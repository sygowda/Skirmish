using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class ChestDestroyAnalytics
{
    private static string chestDestroyTimeTrackerPath = "Assets/Sources/chestDestroyTimeTrackerAnalytics.csv";
    private static DateTime[] p1ChestDestroyedTime; // how much time the chest of p1 is destroyed
    private static DateTime[] p2ChestDestroyedTime;

    public static void initializep1ChestDestroyedTime()
    {
        p1ChestDestroyedTime = new DateTime[2];
        p1ChestDestroyedTime[0] = new DateTime(DateTime.MinValue.Ticks);
        p1ChestDestroyedTime[1] = new DateTime(DateTime.MinValue.Ticks);
        Debug.Log(p1ChestDestroyedTime[0]);
    }

    public static void initializep2ChestDestroyedTime()
    {
        p2ChestDestroyedTime = new DateTime[2];
        p2ChestDestroyedTime[0] = new DateTime(DateTime.MinValue.Ticks);
        p2ChestDestroyedTime[1] = new DateTime(DateTime.MinValue.Ticks);
        Debug.Log(p2ChestDestroyedTime[0]);
    }

    public static void setP1ChestDestroyedTime()
    {
        //Debug.Log("look at this!");
        //Debug.Log(p1ChestDestroyedTime[0]);
        //Debug.Log(p1ChestDestroyedTime[1]);
        if (p1ChestDestroyedTime[0] == DateTime.MinValue)
        {
            p1ChestDestroyedTime[0] = DateTime.Now;
        }
        else
        {
            p1ChestDestroyedTime[1] = DateTime.Now;
        }

    }

    public static void setP2ChestDestroyedTime()
    {

        if (p2ChestDestroyedTime[0] == DateTime.MinValue)
        {
            p2ChestDestroyedTime[0] = DateTime.Now;
        }
        else
        {
            p2ChestDestroyedTime[1] = DateTime.Now;
        }
    }

    public static void saveChestTimer()
    {
        if (!File.Exists(chestDestroyTimeTrackerPath))
        {
            string chestHeader = "Player" + ", " + "chest number" + ", " + "time spent" + Environment.NewLine;
            File.WriteAllText(chestDestroyTimeTrackerPath, chestHeader);
        }

        DateTime startTiming = GameController.startTime;
        String helper = "This game starts at " + startTiming + Environment.NewLine;
        File.AppendAllText(chestDestroyTimeTrackerPath, helper);

        //Debug.Log(p2ChestDestroyedTime[0]);
        string player1Destroyed1 = "Player1" + "," + p2ChestDestroyedTime[0] + Environment.NewLine;
        File.AppendAllText(chestDestroyTimeTrackerPath, player1Destroyed1);

        string player1Destroyed2 = "Player1" + "," + p2ChestDestroyedTime[1] + Environment.NewLine;
        File.AppendAllText(chestDestroyTimeTrackerPath, player1Destroyed2);

        string player2Destroyed1 = "Player2" + "," + p1ChestDestroyedTime[0] + Environment.NewLine;
        File.AppendAllText(chestDestroyTimeTrackerPath, player2Destroyed1);

        string player2Destroyed2 = "Player2" + "," + p1ChestDestroyedTime[1] + Environment.NewLine;
        File.AppendAllText(chestDestroyTimeTrackerPath, player2Destroyed2);

    }

}

