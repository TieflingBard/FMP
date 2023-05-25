using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStart : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GlobalLightCheckV2.instance.lightSwitchStart = true;
            Destroy(this.gameObject);
        }
    }
}
