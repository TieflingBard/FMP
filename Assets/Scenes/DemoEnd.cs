using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DemoEnd : MonoBehaviour
{
    public TextMeshProUGUI finalText;
    public float timer;
    public float deathCount;




    private void Update()
    {
        LevelDisplay.timerStop = true;
        timer = TimerHold.instance.timer;
        deathCount = TimerHold.instance.deaths; 
        TimeSpan time = TimeSpan.FromSeconds(timer);
        finalText.text = ("Thank you for playing Oscuro. Your final time was:" + "<br>" + (time.ToString(@"mm\:ss\:fff") + "<br>" + "Deaths: " + deathCount + "<br>" + "Press escape to quit"));
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
