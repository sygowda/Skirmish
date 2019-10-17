using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    //private static string name;
    //private static int level, coin;

    private static string name;
    private static int level, coin;

    public static void initialize(string name_, int level_, int coin_)
    {
        name = name_;
        level = level_;
        coin = coin_;
    }
    public static string getName()
    {
        return name;
    }
    public static int getLevel()
    {
        return level;
    }
    public static int getCoin()
    {
        return coin;
    }
    public static void addCoin(int amount)//amount can be negative
    {
        coin += amount;
        if (coin < 0)
            coin = 0;
        
    }


}
