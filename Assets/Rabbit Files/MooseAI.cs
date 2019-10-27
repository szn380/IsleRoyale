using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseAI : MonoBehaviour {
    public Transform Gore;
    public Transform BabyMoose;
    public float ageLimitCal = 150;
    public float hungerLimitCal = 25;        // time value that determines when a moose dies of hunger
    public float MatingTimeCal = 20;

    float timeOutTime = 0;
    float age = 0;
    float hunger = 0;

    void Start()
    {
        timeOutTime = 0;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Moose")
        {
            if (timeOutTime >= MatingTimeCal)
            {
                Instantiate(BabyMoose, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                // newRabbit.transform.Rotate(Vector3.down);
                timeOutTime = 0;
            }
        }
        else if (collision.gameObject.tag == "LargePlant")
        {
            hunger = 0;
        }
    }

    private void Update()
    {
        timeOutTime += Time.deltaTime;
        age += Time.deltaTime;
        hunger += Time.deltaTime;
        if ((age > ageLimitCal) || (hunger > hungerLimitCal))
        {
            Instantiate(Gore, new Vector3(transform.position.x, 0.0f, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }

    }
}
