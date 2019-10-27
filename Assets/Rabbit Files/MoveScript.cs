using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveScript : MonoBehaviour {
    //  wander mode - move in a straight line until a timeout, then pick new random direction to move in

    public int wanderDistanceCal = 1;           // Calibration for move distance for wander mode
    public float WanderTriggerCal = 5.0f;       // Calibration for time until new wander direction is set
    float WanderTriggerTime = 5.0f;             // local count down time to trigger new wander direction (set equal to WanderTriggerCal)
    int moveDirection = 0;                      // 90 degree direction to move in wander mode 0 - forward, 1 - left, 2 - back, 3 - right

    // Use this for initialization
    void Start () {
        WanderTriggerTime = WanderTriggerCal;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldLocation = transform.position;   // current location of gameobject before move calculated
        Vector3 direction = Vector3.forward;        // direction of movement
        Quaternion rotation;                    // calculated rotation to match the direction of movement

        WanderTriggerTime -= Time.deltaTime;
        if (WanderTriggerTime <= 0.0f)
        {
            // print("Time Out");
            WanderTriggerTime = WanderTriggerCal;
            moveDirection = Random.Range(0, 4);
        }

        // move gameobject during wander mode
        oldLocation = transform.position;
        switch (moveDirection)
        {
            case 0:
                transform.position += Vector3.forward * Time.deltaTime * (float)wanderDistanceCal;
                direction = transform.position + Vector3.forward - oldLocation;
                break;
            case 1:
                transform.position += Vector3.left * Time.deltaTime * (float)wanderDistanceCal;
                direction = transform.position + Vector3.left - oldLocation;
                break;
            case 2:
                transform.position += Vector3.back * Time.deltaTime * (float)wanderDistanceCal;
                direction = transform.position + Vector3.back - oldLocation;
                break;
            case 3:
                transform.position += Vector3.right * Time.deltaTime * (float)wanderDistanceCal;
                direction = transform.position + Vector3.right - oldLocation;
                break;
            default:
                break;
        }

        // rotate gameObject to face direction of movement
        rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
