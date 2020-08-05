using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    //需要設定開始之前某些功能不行用
    //ex: 駕駛 計時 bot

    int time = 3;
    public Text timer;

    void Start() {
        InvokeRepeating("count", 1, 1);
    }

    void count() {
        time -= 1;
        if(time == 0) {
            
            timer.text = "Start!!!";
            CancelInvoke("count");
        }
    }
}
