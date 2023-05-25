using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        TentacleTwo.gameEnd = true;

    }
}
