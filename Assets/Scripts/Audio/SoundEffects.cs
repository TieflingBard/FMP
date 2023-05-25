using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource src;
    public AudioClip walkSoundEffect, dashSoundeffect;
    
    
    
    private void Update()
    {
       if (!src.isPlaying)
        {
            if (PlayerController.isWalking)
            {

                src.clip = walkSoundEffect;
                src.Play();
            }
            else
            {
                src.Stop();
            }
        }
        
    }

}
