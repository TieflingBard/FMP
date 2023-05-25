using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLantern : MonoBehaviour
{
    [SerializeField] GameObject lantern;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            lantern.SetActive(true);
            Destroy(this.gameObject);

        }
    }
}
