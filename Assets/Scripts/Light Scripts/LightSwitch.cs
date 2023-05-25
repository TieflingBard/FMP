using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] Light2D bigLight;
    private float lightOnTimer = 10f;
    private float lightOffTimer = 3f;




    private void Update()
    {
        lightOnTimer -= Time.deltaTime;
        if (lightOnTimer < 0.1f)
        {
          bigLight.enabled = false;
          lightOffTimer -= Time.deltaTime;
          if(lightOffTimer < 0.1f)
          {
          bigLight.enabled = true;
          lightOnTimer = 10f;
          lightOffTimer = 3f;
         }
          
        }

    }





}
