using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class textdeath : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public bool flag;

    // Update is called once per frame
    private void Update()
    {
        int scrap = DataHolder.GetScrapInfo();

        messageText.text = "Очков за сбор металлолома: " + scrap + "/310";

        flag = false;
    }
}
