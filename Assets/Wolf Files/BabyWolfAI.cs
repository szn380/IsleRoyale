using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyWolfAI : MonoBehaviour {
 public Transform Wolf;


    float age = 0;

    void OnTriggerEnter(Collider collision)
    {
        // print("Collision ENTER");
    }

    private void Update()
    {
        age += Time.deltaTime;

        if (age >= 15)
        {
            Instantiate(Wolf, new Vector3(transform.position.x, 0.0f, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}
