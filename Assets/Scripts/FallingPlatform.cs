using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField]private float fallDelay = 1f;
    [SerializeField]private float destroyDelay = 2f;
    [SerializeField]private float maxFallSpeed;
    [SerializeField]private SpriteRenderer _sr;
    [SerializeField]private Sprite platformActive, platformInactive;
    [SerializeField]private AudioSource _src;
    [SerializeField]private AudioClip activate, respawn;
    private Vector3 startPos;
    public Rigidbody2D platformRB;
    private bool isFalling = false;

    private void Start()
    {
        _sr.sprite = platformInactive;
        startPos = transform.position;
    }
    private void Update()
    {
        if (isFalling)
        {
            platformRB.velocity = new Vector2(platformRB.velocity.x, Mathf.Max(platformRB.velocity.y, -maxFallSpeed));
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling) 
        {
            _src.PlayOneShot(activate);
            StartCoroutine(fall());
        }
    }

    private IEnumerator fall()
    {
        _sr.sprite = platformActive;
        yield return new WaitForSeconds(fallDelay);
        isFalling = true;
        platformRB.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyDelay);
        platformRB.velocity = new Vector2(0f,0f);
        transform.position = startPos;
        isFalling = false;
        _sr.sprite = platformInactive;
        platformRB.bodyType = RigidbodyType2D.Kinematic;
        _src.PlayOneShot(respawn);
    }
}
