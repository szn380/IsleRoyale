using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBeaver : MonoBehaviour {
    public Transform Gore;
    public Transform Beaver;

    float timeOutTime = 0;
    float age = 0;


    void Start()
    {
        timeOutTime = 0;
        age = 0;
    }

    private void Update()
    {
        timeOutTime += Time.deltaTime;
        age += Time.deltaTime;

        if (age >= 15)
        {
            Instantiate(Beaver, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}
