using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {

    public Transform StumpPrefab;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Beaver")
        {
            Instantiate(StumpPrefab, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}
