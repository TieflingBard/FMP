using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TentacleTwo : MonoBehaviour
{
    public int length;
    public LineRenderer lr;
    public Vector3[] segmentPoses;
    private Vector3[] segmentVelocity;
    public Transform targetDirection;
    public float targetDistance;
    public float smoothspeed;
    public static bool mantaHasDied = false;
    public static bool gameEnd = false;
  

    [Range(0, 100)] [SerializeField] float wiggleSpeed;
    [Range(0, 100)] [SerializeField] float wiggleMagnitude;
    public Transform wiggleDirection;

    public Transform secondTarget;

    [SerializeField] NavMeshAgent mantaAgent;

    public Transform mantaPosition;
    public static Transform mantaRespawn;
    [SerializeField] Transform startPoint;


    // Start is called before the first frame update
    void Start()
    {
        lr.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentVelocity = new Vector3[length];
       
        gameEnd = false;
    }
    private void Awake()
    {
        mantaRespawn = startPoint;
        mantaPosition.position = mantaRespawn.position;
    }

    // Update is called once per frame
    void Update()
    {
        // segmentPoses[0] = secondTarget.position;

        wiggleDirection.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);


        segmentPoses[0] = targetDirection.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetpos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDistance;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetpos, ref segmentVelocity[i], smoothspeed);
        }
        lr.SetPositions(segmentPoses);
 



        if (mantaHasDied)
        {
            mantaRespawnThing();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            mantaAgent.enabled = false;
            mantaPosition.position = mantaRespawn.position;
            mantaAgent.enabled = true;
            PlayerDeath.instance.playerHasDied = true;
            if (gameEnd)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void mantaRespawnThing()
    {
        mantaAgent.enabled = false;
        mantaPosition.position = mantaRespawn.position;
        mantaAgent.enabled = true;
        mantaHasDied = false;
    }
    
   




}
