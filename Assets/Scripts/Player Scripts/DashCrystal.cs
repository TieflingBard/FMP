using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCrystal : MonoBehaviour
{
    public SpriteRenderer crystalSprite;
    public Sprite crystalOn, crystalOff;
    private bool crystalActive = true;
    [SerializeField]AudioSource _src;
    [SerializeField]AudioClip activate, respawn;
    private void Start()
    {
        crystalSprite.sprite = crystalOn;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && crystalActive)
        {
            PlayerController.instance.canDash = true;
            crystalSprite.sprite = crystalOff;
            crystalActive = false;
            _src.PlayOneShot(activate);
            StartCoroutine(crystalCooldown());           
        }
    }
    private IEnumerator crystalCooldown()
    {
        yield return new WaitForSeconds(3f);
        crystalActive = true;
        crystalSprite.sprite = crystalOn;
        _src.PlayOneShot(respawn);
    }
}
