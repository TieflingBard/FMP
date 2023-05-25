using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeadRotate : MonoBehaviour
{
    public float rotationspeed;
    private Vector2 direction;
    [Range(0,100)][SerializeField] float movespeed;
    [SerializeField] Vector3 playerPoos;
    [SerializeField] NavMeshAgent mantaAgent;
    [SerializeField] Transform playerPos;
    public static float _speed;
    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    private void Update()
    {
        mantaAgent.speed = _speed;
        rotateManta();
        changeMantaTarget();
        setTargetPosition();
    }

    // Update is called once per frame
    void rotateManta()
    {
        direction = new Vector3(playerPos.position.x, playerPos.position.y) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationspeed * Time.deltaTime);
    }

    void changeMantaTarget()
    {
        mantaAgent.SetDestination(new Vector3(playerPoos.x, playerPoos.y, transform.position.z));
    }
    void setTargetPosition()
    {
        playerPoos = playerPos.position;
    }
}
