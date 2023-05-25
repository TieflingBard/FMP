using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    private void Update()
    {
        AudioListener.volume = volumeSlider.value;
    }

}
