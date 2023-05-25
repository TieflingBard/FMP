using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightCheckV1 : MonoBehaviour
{
    public bool isInLight;
    public static GlobalLightCheckV1 instance;
    private Light2D _light;


    private void Awake()
    {
        instance = this;
        _light = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (isInLight)
        {
            _light.color = Color.green;

        }
        else 
        {
            _light.color = Color.red;

        }
       
    
    }





}