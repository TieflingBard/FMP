using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiSolidPlatformDrop : MonoBehaviour
{
    [SerializeField] PlatformEffector2D platformE;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            platformE.rotationalOffset = 180f;
            Debug.Log("wawa");
        }
        else
        {
            platformE.rotationalOffset = 0f;
        }
    }
}
