using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnobject : MonoBehaviour
{
    [SerializeField] Transform thisObject;
    [SerializeField] AudioSource _src;
    [SerializeField] AudioClip checkpointActive;
    private bool hasBeenActivated;

    private void Start()
    {
        hasBeenActivated = false;
    }




    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasBeenActivated)
        {
            PlayerDeath.instance.currentRespawnPoint = thisObject.transform;
            _src.PlayOneShot(checkpointActive);
            hasBeenActivated = true;
        }
    }
}
