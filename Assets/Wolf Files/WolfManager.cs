using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfManager : MonoBehaviour {

    public Vector3 RabbitPosition = new Vector3(0, 0, 0);   // location of detected rabbit
    public int RabbitDetected = 0;          // Is there a rabbit to hunt
    public float hungerTimeCal = 30;        // time value that determines when a wolf becomes hungry
    public float starveTimeCal = 60;
    public float simStartStarveImmuneTimeCal = 90;
    public float simStartStarveImmune = 1;  // at start of sim, wolf is immune from starving
    public float simStartStarveImmuneTime = 0;  // sim start starve immunity timer
    public int wolfHungry = 0;              // time based counter used to determine when a wolf is hungry (read to hunt rabbits)
    public float wolfMateTimer = 0;
    public float wolfMateTimeCal = 30;
    public Vector3 WolfMatePosition = new Vector3(0, 0, 0);
    public int WolfMateDetected = 0;
}
