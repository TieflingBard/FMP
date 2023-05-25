using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Linq;

public class GlobalLightCheckV2 : MonoBehaviour
{   
    //Light Check variables
    [SerializeField] Transform playerTransform;
    public Vector2 playerLocation;
    public List<GameObject> lightList = new List<GameObject>();
    public static GlobalLightCheckV2 instance;
    
    //Light switch variable
    [SerializeField] Light2D bigLight;
    private float lightOnTimer = 7f;
    private float lightOffTimer = 2.25f;

    //Sound variables
    [SerializeField]private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    private bool lightSwitchAudio;
    public bool lightSwitchStart = false;

    //Animator
    [SerializeField] Animator Anim;



    private void Start()
    {
        //Append all lights to a list
        lightList = GameObject.FindGameObjectsWithTag("Light").ToList();
        instance = this;
    }



    private void Update()
    {      
        //Check if variable is true
        if (!isInLight() && bigLight.enabled == false)
        {
            PlayerDeath.instance.playerHasDied = true;
        }





        if (lightSwitchStart)
        {
            lightOnTimer -= Time.deltaTime;
            if (lightOnTimer < 0.1f)
            {
                bigLight.enabled = false;
                lightSwitchAudio = true;
                lightOffTimer -= Time.deltaTime;
                if (lightOffTimer < 0.1f)
                {
                    lightSwitchAudio = false;
                    bigLight.enabled = true;
                    lightOnTimer = 7f;
                    lightOffTimer = 2.25f;

                }

            }
        }
        if (lightSwitchStart)
        {
            if (bigLight.enabled == true)
            {
                Anim.SetBool("LightOn", true);
            }
            else if (bigLight.enabled == false)
            {
                Anim.SetBool("LightOn", false);
            }
        }
        

        if (lightSwitchAudio)
        {
            audioSource1.Play();
        }
        else if (!lightSwitchAudio)
        {
            audioSource2.Play();
        }






    }

    //Check if player is in light
    public bool isInLight()
    {
        bool isInLight2 = true;
        //Move through list
        for (int i = 0; i < lightList.Count; i++)
        {
            //Determine distance to player
            Light2D currentLight = lightList[i].GetComponent<Light2D>();
            playerLocation = new Vector2(playerTransform.position.x,playerTransform.position.y);
            float distanceToPlayer = Vector2.Distance(playerLocation, currentLight.transform.position);
            //Compare distance to light size
            if (distanceToPlayer > currentLight.pointLightOuterRadius)
            {
                isInLight2 = false;
            }
            else if (distanceToPlayer < currentLight.pointLightOuterRadius)
            {
                isInLight2 = true;
                break;
            }
        }
        if (isInLight2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void resetLight()
    {
        lightOnTimer = 0f;
    }



}
