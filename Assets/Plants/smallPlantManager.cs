using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallPlantManager : MonoBehaviour {

    float growTimer = 0;
    public float plantGrowTimeCal = 120f;
    public Transform PlantPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        growTimer += Time.deltaTime;

        if (growTimer >= plantGrowTimeCal)
        {
            Instantiate(PlantPrefab, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
            growTimer = 0;
            Destroy(gameObject);
        }

    }
}
