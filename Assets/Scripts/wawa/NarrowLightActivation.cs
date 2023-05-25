using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NarrowLightActivation : MonoBehaviour
{
    [SerializeField] Light2D lightSource;
    [SerializeField] private float lightTime;
    private float lightTimeLoss;
    private bool lightHit;
    [Range(0, 1000)] [SerializeField] float darkSpeed;
    private float lightradius;
    private float angle1;
    private float angle2;
    private float angle3;
    private float angle4;
    private float angle5;
    private float angle6;
    private float angle7;

    private bool playerDetected;
    //private float[] rayCastChecks;
  
    private bool playerInLight;

    //public GameObject pointOfOrigin;

    private void Start()
    {
        lightSource.pointLightOuterRadius = 1;
    }
    void Update()
    {

        //Vector2 direction = GetDirectionVector2D(angle);

        //RaycastHit2D TestRay = Physics2D.Raycast(pointOfOrigin.transform.position, Vector2.right,lightSource.pointLightOuterRadius);
        //RaycastHit2D TestRay = Physics2D.Raycast(pointOfOrigin.transform.position, direction, lightradius);

        //if (LightDetect())
        //{
        //    playerInLight = true;
        //}
        //else
        //{
        //    playerInLight = false;
        //}

        

        if (lightHit == false)
        {
            lightTimeLoss = lightTime;
            lightSource.pointLightOuterRadius = 1;

        }
        else if (lightHit == true)
        {
            lightTimeLoss -= Time.deltaTime * darkSpeed;

            lightSource.pointLightOuterRadius = lightTimeLoss;
        }

        if (lightTimeLoss < 1)
        {
            lightHit = false;
        }

        lightradius = lightSource.pointLightOuterRadius;

        if (SecondLight())
        {
            playerInLight = true;
        }
        else
        {
            playerInLight = false;
        }
        Debug.Log(playerInLight);


       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            lightSource.pointLightOuterRadius = 8;
            lightHit = true;


            


        }
    }

    public Vector2 GetDirectionVector2D(float angle)
    {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
    }

    
          
        




    private bool SecondLight()
    {
        angle1 = lightSource.pointLightOuterAngle - 6f;
        angle2 = lightSource.pointLightOuterAngle - 8f;
        angle3 = lightSource.pointLightOuterAngle - 10f;
        angle4 = lightSource.pointLightOuterAngle - 12f;
        angle5 = lightSource.pointLightOuterAngle - 14f;
        angle6 = lightSource.pointLightOuterAngle - 14f;
        angle7 = lightSource.pointLightOuterAngle - 14f;

        Vector2 direction1 = GetDirectionVector2D(angle1);
        Vector2 direction2 = GetDirectionVector2D(angle2);
        Vector2 direction3 = GetDirectionVector2D(angle3);
        Vector2 direction4 = GetDirectionVector2D(angle4);
        Vector2 direction5 = GetDirectionVector2D(angle5);
        Vector2 direction6 = GetDirectionVector2D(angle6);
        Vector2 direction7 = GetDirectionVector2D(angle7);

        RaycastHit2D CheckRay1 = Physics2D.Raycast(transform.position, direction1, lightradius);
        RaycastHit2D CheckRay2 = Physics2D.Raycast(transform.position, direction2, lightradius);
        RaycastHit2D CheckRay3 = Physics2D.Raycast(transform.position, direction3, lightradius);
        RaycastHit2D CheckRay4 = Physics2D.Raycast(transform.position, direction4, lightradius);
        RaycastHit2D CheckRay5 = Physics2D.Raycast(transform.position, direction5, lightradius);
        RaycastHit2D CheckRay6 = Physics2D.Raycast(transform.position, direction6, lightradius);
        RaycastHit2D CheckRay7 = Physics2D.Raycast(transform.position, direction7, lightradius);

        Debug.DrawRay(transform.position, direction1 * lightradius, Color.blue);
        Debug.DrawRay(transform.position, direction2 * lightradius, Color.red);
        Debug.DrawRay(transform.position, direction3 * lightradius, Color.green);
        Debug.DrawRay(transform.position, direction4 * lightradius, Color.yellow);
        Debug.DrawRay(transform.position, direction5 * lightradius, Color.white);
        Debug.DrawRay(transform.position, direction6 * lightradius, Color.cyan);
        Debug.DrawRay(transform.position, direction7 * lightradius, Color.black);

        if (CheckRay1.collider.CompareTag("Player") || CheckRay2.collider.CompareTag("Player") || 
            CheckRay3.collider.CompareTag("Player") || CheckRay4.collider.CompareTag("Player") || 
            CheckRay5.collider.CompareTag("Player") || CheckRay6.collider.CompareTag("Player") ||
            CheckRay7.collider.CompareTag("Player"))
        {
            playerDetected = true;
            //Debug.Log(playerDetected);
                
        }
        else
        {
            playerDetected = false;

        }
      
        

        if (playerDetected == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
