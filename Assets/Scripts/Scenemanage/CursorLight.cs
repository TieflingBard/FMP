using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CursorLight : MonoBehaviour
{
    [SerializeField] private Transform cursorLightPos;
    private Vector3 cursorPos;


    private void Update()
    {
        cursorPos = Input.mousePosition;
        cursorPos.z = Camera.main.nearClipPlane;
        cursorLightPos.position = Camera.main.ScreenToWorldPoint(cursorPos);
    }
}
