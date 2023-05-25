using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleMantaSpeed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HeadRotate._speed *= 1.2f;
    }
}
