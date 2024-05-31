using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public bool flag;

    private void Awake()
    {
        flag = true;
    }
    // Update is called once per frame
    private void Update()
    {
        if (flag)
        {
            int scrap = DataHolder.GetScrapInfo();

            string rank = "SSS";

            if (scrap == 310)
            {
                rank = "SSS";
            }
            else if (scrap >= 280)
            {
                rank = "S";
            }
            else if (scrap >= 250)
            {
                rank = "A";
            }
            else if (scrap >= 220)
            {
                rank = "B";

            }
            else if (scrap >= 190)
            {
                rank = "C";
            }
            else if (scrap >= 160)
            {
                rank = "D";
            }
            else if (scrap >= 130)
            {
                rank = "E";
            }
            else
            {
                rank = "F";
            }

            messageText.text = "Очков за сбор металлолома: " + scrap + "/310" + "\n" + "\n" + "Ранг  " + rank;

            flag = false;
        }

    }
}
