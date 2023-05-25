using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2End : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.maxFallSpeed = 22f;
            PlayerController.instance.canDash = false;
            GlobalLightCheckV2.instance.lightSwitchStart = false;
        }
        
    }
}
