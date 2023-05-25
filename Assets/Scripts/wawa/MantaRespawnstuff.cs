using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantaRespawnstuff : MonoBehaviour
{
    [SerializeField] Transform mantarespawnPoint;
    [SerializeField] float _mantaSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TentacleTwo.mantaRespawn = mantarespawnPoint;
            HeadRotate._speed = _mantaSpeed;
        }
        
    }

}
