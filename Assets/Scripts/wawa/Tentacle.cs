using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public int length;
    public LineRenderer lr;
    public Vector3[] segmentPoses;
    private Vector3[] segmentVelocity;
    public Transform targetDirection;
    public float targetDistance;
    public float smoothspeed;
    public float trailSpeed;

    [Range(0, 100)] [SerializeField] float wiggleSpeed;
    [Range(0, 100)] [SerializeField] float wiggleMagnitude;
    public Transform wiggleDirection;

    
  


    // Start is called before the first frame update
    void Start()
    {
        lr.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentVelocity = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {
        
        wiggleDirection.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);


        segmentPoses[0] = targetDirection.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDirection.right * 
                targetDistance, ref segmentVelocity[i], smoothspeed + i / trailSpeed );
        }
        lr.SetPositions(segmentPoses);
    }
}
