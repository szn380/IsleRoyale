using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRabbit : MonoBehaviour {
 public Transform Gore;
 public Transform Rabbit;
 public Transform Wolf;
 public Transform BabyRabbit;
 public Transform BabyWolf;

    float timeOutTime = 0;
    float WolfHunger = 0;
    float age = 0;


    void Start()
    {
        WolfHunger = 0;
        age = 0;
        timeOutTime = 0;
    }

    void OnTriggerEnter(Collider collision)
    {
        print("Collision ENTER");
        if ((gameObject.tag == "Wolf") && (collision.gameObject.tag != "Wolf"))
        {
            WolfHunger = 0;
        }
        else if ((gameObject.tag != "Wolf") && (collision.gameObject.tag == "Wolf"))
        {
            Instantiate(Gore, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
        else if ((collision.gameObject.tag == "Rabbit") && (gameObject.tag == "Rabbit"))
        {
            if (timeOutTime >= 15.0)
            {
                Instantiate(BabyRabbit, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                timeOutTime = 0;
            }
        }
        else if ((collision.gameObject.tag == "Wolf") && (gameObject.tag == "Wolf"))
        {
            if (timeOutTime >= 5.0)
            {
                print("Add Baby Wolf");
                Instantiate(BabyWolf, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                timeOutTime = 0;
            }
        }
    }

    private void Update()
    {
        timeOutTime += Time.deltaTime;
        WolfHunger += Time.deltaTime;
        age += Time.deltaTime;

        if ((gameObject.tag == "Wolf") && (WolfHunger >= 30))
        {
            print("Wolf Starved to Death");
            Instantiate(Gore, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
        else if ((gameObject.tag == "BabyRabbit")  && (age >=30))
        {
            Instantiate(Rabbit, new Vector3(transform.position.x, 0.5f, transform.position.z ), transform.rotation);
            Destroy(gameObject);
        }
        else if ((gameObject.tag == "BabyWolf") && (age >= 5))
        {
            WolfHunger = 0;
            Instantiate(Wolf, new Vector3(transform.position.x, 0.0f, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        print("Collision EXIT");
    }
}
