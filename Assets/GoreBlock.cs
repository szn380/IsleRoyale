using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreBlock : MonoBehaviour {
    public float deleteBlockTimeCal = 60;
    float deleteTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        deleteTimer += Time.deltaTime;
        if (deleteTimer >= deleteBlockTimeCal)
        {
            Destroy(gameObject);
        }
	}
}
