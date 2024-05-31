using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder
{
    public static DataHolder Instance { get; set; }
    public static int scrap = 0;
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
}
