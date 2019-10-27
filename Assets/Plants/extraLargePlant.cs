using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraLargePlant : MonoBehaviour {

    public Transform PlantPrefab;

    void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Moose") || (collision.gameObject.tag == "BabyMoose"))
        {
            Instantiate(PlantPrefab, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}
