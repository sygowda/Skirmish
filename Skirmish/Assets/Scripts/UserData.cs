using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    //private static string name;
    //private static int level, coin;

    private static string name;
    private static int level, coin;
    private static int chest1_1;
    private static int chest1_2;
    private static int chest2_1;
    private static int chest2_2;

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

    public static int getChest1_1()
    {
        return chest1_1;
    }

    public static int getChest1_2()
    {
        return chest1_2;
    }

    public static int getChest2_1()
    {
        return chest2_1;
    }

    public static int getChest2_2()
    {
        return chest2_2;
    }

    public static void setChest1_1(int val)
    {
        chest1_1 = val;
    }

    public static void setChest1_2(int val)
    {
        chest1_2 = val;
    }

    public static void setChest2_1(int val)
    {
        chest2_1 = val;
    }

    public static void setChest2_2(int val)
    {
        chest2_2 = val;
    }
}
