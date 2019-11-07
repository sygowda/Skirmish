using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    //private static string name;
    //private static int level, coin;

    private static string name;
    private static int level, coin;
    private static int[] chest1 = new int[2];
    private static int[] chest2 = new int[2];


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

    public static int getChest1(int index)
    {
        return chest1[index];
    }

    public static int getChest2(int index)
    {
        return chest2[index];
    }


    public static void setChest1(int val,int index)
    {
        chest1[index] = val;
    }
    public static void setChest2_2(int val,int index)
    {
        chest2[index] = val;
    }
}
