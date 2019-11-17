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

    public static void setP1ChestDestroyedTime(int index)
    {
        p1ChestDestroyedTime[index] = DateTime.Now;

    }

    public static void setP2ChestDestroyedTime(int index)
    {
        p2ChestDestroyedTime[index] = DateTime.Now;
    }

    public static void saveChestTimer()
    {
        if (!File.Exists(chestDestroyTimeTrackerPath))
        {
            string chestHeader = "Game start time" + "," + "Player" + "," + "Chest" + "," + "Chest value" + "," + "Chest destroyed time" + "," + "time spent" + Environment.NewLine;
            File.WriteAllText(chestDestroyTimeTrackerPath, chestHeader);
        }

        DateTime startTiming = GameController.startTime;

        string player1Destroyed1;
        string player1Destroyed2;
        string player2Destroyed1;
        string player2Destroyed2;
        if (p1ChestDestroyedTime[0] == DateTime.MinValue)
        {
            player1Destroyed1 = startTiming + "," + "Player1" + "," + "silver chest" + "," + UserData.getChest1(0) + "," + "not destroyed till the end" + Environment.NewLine;
        }
        else
        {
            player1Destroyed1 = startTiming + "," + "Player1" + "," + "silver chest" + "," + UserData.getChest1(0) + "," + p1ChestDestroyedTime[0] + ","+ (p1ChestDestroyedTime[0] - startTiming) + Environment.NewLine;
        }

        if (p1ChestDestroyedTime[1] == DateTime.MinValue)
        {
            player1Destroyed2 = startTiming + "," + "Player1" + "," + "gold chest" + "," + UserData.getChest1(1) + "," + "not destroyed till the end" + Environment.NewLine;
        }
        else
        {
            player1Destroyed2 = startTiming + "," + "Player1" + "," + "gold chest"+ ","+UserData.getChest1(1)+ ","+ p1ChestDestroyedTime[1] + "," + (p1ChestDestroyedTime[1] - startTiming) + Environment.NewLine;
        }

        if (p2ChestDestroyedTime[0] == DateTime.MinValue)
        {
            player2Destroyed1 = startTiming + "," + "Player2" + "," + "silver chest" + "," + UserData.getChest2(0) + "," + "not destroyed till the end" + Environment.NewLine;
        }
        else
        {
            player2Destroyed1 = startTiming + "," + "Player2" + "," + "silver chest" + "," + UserData.getChest2(0) + "," + p2ChestDestroyedTime[0] + ","+ (p2ChestDestroyedTime[0] - startTiming) + Environment.NewLine;
        }

        if (p2ChestDestroyedTime[1] == DateTime.MinValue)
        {
            player2Destroyed2 = startTiming + "," + "Player2" + "," + "gold chest" + "," + UserData.getChest2(1) + "," + "not destroyed till the end" + Environment.NewLine;
        }
        else
        {
            player2Destroyed2 = startTiming + "," + "Player2" + "," + "gold chest" + "," + UserData.getChest2(1) + "," + p2ChestDestroyedTime[1] + "," + (p2ChestDestroyedTime[1] - startTiming) + Environment.NewLine;
        }

        File.AppendAllText(chestDestroyTimeTrackerPath, player1Destroyed1);
        File.AppendAllText(chestDestroyTimeTrackerPath, player1Destroyed2);
        File.AppendAllText(chestDestroyTimeTrackerPath, player2Destroyed1);
        File.AppendAllText(chestDestroyTimeTrackerPath, player2Destroyed2);
    }

}

