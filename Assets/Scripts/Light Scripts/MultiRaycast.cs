using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiRaycast : MonoBehaviour
{
    public Transform rayStart;
    public int rayResolution = 5;
    public Ray2D castRay;
    private float StartAngle = 0f;
    private float angle;
    private float angleIncrement = 2f;
    public bool[] hitOutcomes;

    private void Awake()
    {
        angle = StartAngle;
        hitOutcomes = new bool[rayResolution];
    }
    private void Update()
    {
        MultipleRaycast();
        //Debug.Log(raycastReturn()); 
    }
    private void MultipleRaycast()
    {       
        Vector2 startPoint = rayStart.position;
        for (int i =0; i < rayResolution; i++)
        {
            Vector2 direction = GetDirectionVector2D(angle);
            RaycastHit2D hit = Physics2D.Raycast(startPoint,direction,100f,9);
            Debug.DrawRay(startPoint, direction, Color.green);
            hitOutcomes[i] = hit.collider != null ? true : false;
            angle += angleIncrement;
        }
        angle = StartAngle;
    }
    public Vector2 GetDirectionVector2D(float angle)
    {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
    }
   
    bool raycastReturn()
    {
        for (int n = 0; n < rayResolution; n++)
        {
            if (hitOutcomes[n] == true)
            {
                return true;
            }
        }
        return false;
    }
       
}
