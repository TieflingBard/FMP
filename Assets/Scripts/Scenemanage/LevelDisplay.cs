using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    public string levelNumber;
    public string screenNumber;
    public float timer;
    public Scene scene;
    public int deathCount;
    [SerializeField] public TextMeshProUGUI infoDisplay;
    public static bool timerStop = false;
    private void Start()
    {
        timer = TimerHold.instance.timer;
    }
    private void Update()
    {
        if (!timerStop)
        {
            timer += Time.deltaTime;
        }
        TimerHold.instance.timer = timer;
        deathCount = TimerHold.instance.deaths;
        levelNumber = scene.name;
        TimeSpan time = TimeSpan.FromSeconds(timer);      
        infoDisplay.text = (time.ToString(@"mm\:ss\:fff") + "<br>" +  "Deaths: " + deathCount);
    }
    public string TruncString(string myStr, int THRESHOLD)
    {
        if (myStr.Length > THRESHOLD)
            return myStr.Substring(0, THRESHOLD);
        return myStr;
    }
}
