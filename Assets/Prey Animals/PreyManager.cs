using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyManager : MonoBehaviour {
    public Vector3 FoodPosition = new Vector3(0, 0, 0);   // location of detected plant
    public int FoodDetected = 0;          // Is there a plant to hunt
    public float hungerTimeCal = 30;        // time value that determines when a prey becomes hungry
    public float starveTimeCal = 60;        // time that determine when a prey dies of starvation
    public int preyHungry = 0;              // time based counter used to determine when a prey is hungry (ready to hunt plants)
    public float preyHunger = 0;            // time counter that indicates how long since a prey last ate
    public float preyMateTimer = 0;
    public float preyMateTimeCal = 15;
    public Vector3 preyMatePosition = new Vector3(0, 0, 0);
    public int preyMateDetected = 0;
}
