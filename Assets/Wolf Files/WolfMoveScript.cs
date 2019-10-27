using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WolfMoveScript : MonoBehaviour {
    // Wolf has two modes of movement
    //  wander mode - move in a straight line until a timeout, then pick new random direction to move in
    //  hunting mode - rabbit has been detected, so move towards the rabbit's position
    //
    //  hunting mode has top priority
    //

    public int wanderDistanceCal = 1;           // Calibration for move distance for wander mode
    public float WanderTriggerCal = 5.0f;       // Calibration for time until new wander direction is set
    public float WolfHunger = 0;
    public Transform Gore;                      // Gore block Prefag reference
    public int debugLevel = 0;                  // sets level of debug commands (higher number, more debug statements)
    float WanderTriggerTime = 5.0f;             // local count down time to trigger new wander direction (set equal to WanderTriggerCal)
    int moveDirection = 0;                      // 90 degree direction to move in wander mode 0 - forward, 1 - left, 2 - back, 3 - right
    int debugLoopCount = 0;                     // update loop counter used in debug statements to determine how many loops to wait until to print out debug info

    void Start () {
        WanderTriggerTime = WanderTriggerCal;
    }
	
	void Update () {
        int moveDirectionOld;                   // the last direction gameobject was moving
        WolfManager wolfManagerInst;            // instance provides access to variables assigned in other script
        Vector3 oldLocation = transform.position;   // current location of gameobject before move calculated
        Vector3 direction = Vector3.forward;    // direction of movement
        Quaternion rotation;                    // calculated rotation to match the direction of movement

        wolfManagerInst = GetComponentInParent<WolfManager>();      // get instance of WolfManager so that this script can access it variables
        WanderTriggerTime -= Time.deltaTime;
        debugLoopCount += 1;
        wolfManagerInst.wolfMateTimer += Time.deltaTime;

        if (WolfHunger >= wolfManagerInst.hungerTimeCal)
        {
            wolfManagerInst.wolfHungry = 1;
        }

        if (debugLevel >= 2) print("WolfMoveScript: Upate()");


        if ((wolfManagerInst.RabbitDetected == 0) && (wolfManagerInst.WolfMateDetected == 0))    // Wolf is not hunting
        {
            // Wander Mode
            // Select a random 90 direction and move wolf along a straight path in that direction until a timeout expires, then pick new direction
            if (WanderTriggerTime <= 0.0f)
            {
                if (debugLevel >= 1) print("MoveScript: WolfMoveScript: Wander Mode");
                WanderTriggerTime = WanderTriggerCal;
                moveDirectionOld = moveDirection;
                moveDirection = Random.Range(0, 4);
            }

            // move gameobject during wander mode
            oldLocation = transform.position;
            switch (moveDirection)
            {
                case 0:
                    transform.position += Vector3.forward * Time.deltaTime * (float)wanderDistanceCal;
                    direction = transform.position + Vector3.forward - oldLocation;
                    break;
                case 1:
                    transform.position += Vector3.left * Time.deltaTime * (float)wanderDistanceCal;
                    direction = transform.position + Vector3.left - oldLocation;
                    break;
                case 2:
                    transform.position += Vector3.back * Time.deltaTime * (float)wanderDistanceCal;
                    direction = transform.position + Vector3.back - oldLocation;
                    break;
                case 3:
                    transform.position += Vector3.right * Time.deltaTime * (float)wanderDistanceCal;
                    direction = transform.position + Vector3.right - oldLocation;
                    break;
                default:
                    break;
            }

            // rotate gameObject to face direction of movement
            rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

        }
        else if (wolfManagerInst.RabbitDetected == 1)
        {
            // hunting mode
            // move to position that corresponds to a detect rabbit, rotate gameobject to face direction of movement
            if (debugLoopCount >= 30)
             {
                if (debugLevel >= 1) print("MoveScript: Hunting Rabbit");
                debugLoopCount = 0;
             }

            if (debugLevel >= 2) print("Wolf Position 1: (" + transform.position.x + "," + transform.position.z + ")");
            if (debugLevel >= 2) print("Rabbit Position 1: (" + wolfManagerInst.RabbitPosition.x + "," + wolfManagerInst.RabbitPosition.z + ")");

            Vector3 separation = wolfManagerInst.RabbitPosition - transform.position;
            float oldYPosition = transform.position.y;

            // this code moves game object towards target rabbit position, also ensuring that each move is at least as large as a minimum distance (0.1f)
            float newX = 0;
            if (wolfManagerInst.RabbitPosition.x > transform.position.x)
                newX = Mathf.Max(separation.x * Time.deltaTime + 0.1f, separation.z * Time.deltaTime * 2);
            else
                newX = Mathf.Min(separation.x * Time.deltaTime - 0.1f, separation.z * Time.deltaTime * 2);
            float newZ = 0;
            if (wolfManagerInst.RabbitPosition.z > transform.position.z)
                newZ = Mathf.Max(separation.z * Time.deltaTime + 0.1f, separation.z * Time.deltaTime * 2);
            else
                newZ = Mathf.Min(separation.z * Time.deltaTime - 0.1f, separation.z * Time.deltaTime * 2);

            oldLocation = transform.position;
            transform.position += new Vector3(newX, 0, newZ);

            // rotate the gameobject to face the direction of movement
            // calculate the direction of the target rabbit, but use y coordination (vertical) of wolf so that it does not rotate up given rabbit y coordinate is different
            direction = wolfManagerInst.RabbitPosition - transform.position - new Vector3(0f, wolfManagerInst.RabbitPosition.y, 0f) + new Vector3(0f, transform.position.y, 0f);
            rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            if (debugLevel >= 2) print("Wolf Position 2: (" + transform.position.x + "," + transform.position.z + ")");
     
            if (Vector3.Distance(wolfManagerInst.RabbitPosition, transform.position) <= 1.75) wolfManagerInst.RabbitDetected = 0;   // handles case where another wolf eats target rabbit first
        }
        else
        {
            // Mating Mode
            // move to position that corresponds to a detected wolf mate, rotate gameobject to face direction of movement
            if (debugLoopCount >= 30)
            {
                if (debugLevel >= 1) print("MoveScript: Seeking Mate");
                debugLoopCount = 0;
            }

            if (debugLevel >= 2) print("Wolf Position 1: (" + transform.position.x + "," + transform.position.z + ")");
            if (debugLevel >= 2) print("Wolf Mate Position 1: (" + wolfManagerInst.WolfMatePosition.x + "," + wolfManagerInst.WolfMatePosition.z + ")");

            Vector3 separation = wolfManagerInst.WolfMatePosition - transform.position;
            float oldYPosition = transform.position.y;

            // this code moves game object towards target wolf mate position, also ensuring that each move is at least as large as a minimum distance (0.1f)
            float newX = 0;
            if (wolfManagerInst.WolfMatePosition.x > transform.position.x)
                newX = Mathf.Max(separation.x * Time.deltaTime + 0.1f, separation.z * Time.deltaTime * 2);
            else
                newX = Mathf.Min(separation.x * Time.deltaTime - 0.1f, separation.z * Time.deltaTime * 2);
            float newZ = 0;
            if (wolfManagerInst.WolfMatePosition.z > transform.position.z)
                newZ = Mathf.Max(separation.z * Time.deltaTime + 0.1f, separation.z * Time.deltaTime * 2);
            else
                newZ = Mathf.Min(separation.z * Time.deltaTime - 0.1f, separation.z * Time.deltaTime * 2);

            oldLocation = transform.position;
            transform.position += new Vector3(newX, 0, newZ);

            // rotate the gameobject to face the direction of movement
            // calculate the direction of the target wolf mate, but use y coordination (vertical) of wolf so that it does not rotate up given wolf mate y coordinate is different
            direction = wolfManagerInst.WolfMatePosition - transform.position - new Vector3(0f, wolfManagerInst.WolfMatePosition.y, 0f) + new Vector3(0f, transform.position.y, 0f);
            rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            if (debugLevel >= 2) print("Wolf Position 2: (" + transform.position.x + "," + transform.position.z + ")");

            if (Vector3.Distance(wolfManagerInst.WolfMatePosition, transform.position) <= 1.75) wolfManagerInst.WolfMateDetected = 0;   // handles case where another wolf mates with target wolf mate first
        }

        // determine if wolf has starved to death
        WolfHunger += Time.deltaTime;
        wolfManagerInst.simStartStarveImmuneTime += Time.deltaTime;

        int check = RandomGen.gameStartOverFlag;

        if (wolfManagerInst.simStartStarveImmuneTime > wolfManagerInst.simStartStarveImmuneTimeCal)
            wolfManagerInst.simStartStarveImmune = 0;
        else if (check == 1)
            wolfManagerInst.simStartStarveImmune = 0;

        if ((WolfHunger >= wolfManagerInst.starveTimeCal) && (wolfManagerInst.simStartStarveImmune == 0))
        {
            if (debugLevel >= 1) print("WolfAI: Wolf Starved to Death");
            // print("WolfAI: Wolf Starved to Death " + WolfHunger + " " + wolfManagerInst.simStartStarveImmuneTime);
            Instantiate(Gore, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}