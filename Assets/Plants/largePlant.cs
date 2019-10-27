using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class largePlant : MonoBehaviour {

    public Transform PlantPrefab;

    void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Rabbit") || (collision.gameObject.tag == "Beaver") || (collision.gameObject.tag == "BabyRabbit") || (collision.gameObject.tag == "BabyBeaver") )
        {
            Instantiate(PlantPrefab, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}
