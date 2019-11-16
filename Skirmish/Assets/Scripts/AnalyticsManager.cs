using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class AnalyticsManager
{

    private static string coolDownTrackerPath = "Assets/Sources/coolDownAnalytics.csv";
    private static string timerTrackerPath = "Assets/Sources/timerAnalytics.csv";

    private static int[] coolDownCounter;
    private static int timer;

    public static void initializeCoolDownTracker(int _coolDownCounter1, int _coolDownCounter2)
    {
        coolDownCounter = new int[2];
        coolDownCounter[0] = _coolDownCounter1;
        coolDownCounter[1] = _coolDownCounter2;
    }

    public static void initializeTimerTracker(int _timer)
    {
        timer = _timer;
    }

    public static void saveAnalyticsData()
    {
        System.DateTime msec = System.DateTime.Now;

        //CoolDownAnalytics
        if (!File.Exists(coolDownTrackerPath))
        {
            string cooldownHeader = "TimeStamp" + "," + "Player" + "," + "CoolDownCount" + System.Environment.NewLine;
            File.WriteAllText(coolDownTrackerPath, cooldownHeader);
        }
        string player1CoolDown = msec + "," + "playerOne" + "," + coolDownCounter[0] + System.Environment.NewLine;
        File.AppendAllText(coolDownTrackerPath, player1CoolDown);
        string player2CoolDown = msec + "," + "playerTwo" + "," + coolDownCounter[1] + System.Environment.NewLine;
        File.AppendAllText(coolDownTrackerPath, player2CoolDown);

        //TimerAnalytics
        if (!File.Exists(timerTrackerPath))
        {
            string cooldownHeader = "TimeStamp" + "," + "TotalTimePerGame" + System.Environment.NewLine;
            File.WriteAllText(timerTrackerPath, cooldownHeader);
        }

        string totalTime = msec + "," + timer + System.Environment.NewLine;
        File.AppendAllText(timerTrackerPath, totalTime);

    }

    public static void increaseCoolDownCount(int player)
    {
        coolDownCounter[player]++;
    }

    public static void setTotalGameDuration(int duration)
    { 
        timer = duration;
        Debug.Log(timer);
    }
}
