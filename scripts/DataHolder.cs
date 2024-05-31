using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder
{
    public static DataHolder Instance { get; set; }
    public static int scrap = 0;
    public static int hp = 5;

    private void Update()
    {
        AddScrap(Hero.Instance.GetScrapInfo());
    }
    public static int GetScrapInfo()
    {
        return scrap;
    }
    public static void AddScrap(int value)
    {
        scrap += value;
    }
    public static void NullScrap()
    {
        scrap = 0;
    }
    public static int GetHpInfo()
    {
        return hp;
    }
    public static void MinusHp(int value)
    {
        hp -= value;
    }
    public static void AddHp(int value)
    {
        hp = value;
    }
}
