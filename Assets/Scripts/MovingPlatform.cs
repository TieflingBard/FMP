using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Sprite platformActive, platformInactive;
    private Vector3 startPos;
    private bool isMoving = false;
    [SerializeField] private float moveDelay = 1f;
    [SerializeField] private Transform endPos;
    [SerializeField] private float speed;
    [SerializeField] Transform player;

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, endPos.position) < 1f)
            {
                player.parent = null;
                transform.position = startPos;
                isMoving = false;
                _sr.sprite = platformInactive;

            }
        }
           
        
    }

    private void Start()
    {
        startPos = transform.position;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
            StartCoroutine(movePlatform());
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }



    private IEnumerator movePlatform()
    {
        _sr.sprite = platformActive;
        yield return new WaitForSeconds(moveDelay);
        isMoving = true;
    }

 

}
