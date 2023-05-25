using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHold : MonoBehaviour
{
    public static TimerHold instance;
    public float timer;
    public int deaths;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    public void destroyThis()
    {
        Destroy(this.gameObject);
    }

}
