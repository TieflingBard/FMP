using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private float rotateZ;
   [Range(0,10000)] [SerializeField] public float rotateSpeed;
   

    private void Update()
    {
        rotateZ += -Time.deltaTime * rotateSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotateZ);
    }










}

