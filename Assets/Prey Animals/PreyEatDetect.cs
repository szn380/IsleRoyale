using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyEatDetect : MonoBehaviour {

    public Transform BabyRabbitPrefab;          // reference to BabyPrey Prefab
    public Transform BabyBeaverPrefab;          // reference to BabyPrey Prefab
    public Transform BabyMoosePrefab;          // reference to BabyPrey Prefab
    public int debugLevel = 0;          // controls the amount of detail printed out for debugging (0 = no debug)      

    float preyMatingTimer = 0;          // counter indicating how long since a prey last mated - determines when it can mate again
    PreyMove preyMoveScriptInst;  // access variables form preyMoveScript
    PreyManager preyManagerInst;        // access variables from PreyManager

    private void Update()
    {
        preyMatingTimer += Time.deltaTime;
    }

    // handle Eat / Mating game oject collisions (eat preys, have baby wolves)
    void OnTriggerEnter(Collider collision)
    {
        preyManagerInst = GetComponentInParent<PreyManager>();      // get instance of PreyManager so that this script can access it variables
        preyMoveScriptInst = GetComponentInParent<PreyMove>();
        if ((collision.gameObject.tag == "LargePlant") && (this.transform.parent.tag != "Moose"))
        {
            // food detected by eat collider, eat the food
            preyManagerInst.preyHunger = 0.0f;
            preyManagerInst.preyHungry = 0;
            preyManagerInst.FoodDetected = 0;
            preyManagerInst.FoodPosition = new Vector3(0f, 0f, 0f);
            if (debugLevel >= 1) print("EatDetect: Just Ate: Hunger 0 " + preyManagerInst.preyHunger + preyManagerInst.FoodDetected);
        }
        else if ((collision.gameObject.tag == "BeaverLodge") && (this.transform.parent.tag == "Beaver"))
        {
            preyManagerInst.preyHunger = 0.0f;
            preyManagerInst.preyHungry = 0;
            preyManagerInst.FoodDetected = 0;
            preyManagerInst.FoodPosition = new Vector3(0f, 0f, 0f);
            print("Entering Beaver Lodge");
            int chance = Random.Range(0, 3);
            if (chance == 2)
            {
                Instantiate(BabyBeaverPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            };
        }
        else if ((collision.gameObject.tag == "ExtraLargePlant") && (this.transform.parent.tag == "Moose"))
        {
            // food detected by eat collider, eat the food
            preyManagerInst.preyHunger = 0.0f;
            preyManagerInst.preyHungry = 0;
            preyManagerInst.FoodDetected = 0;
            preyManagerInst.FoodPosition = new Vector3(0f, 0f, 0f);
            if (debugLevel >= 1) print("EatDetect: Just Ate: Hunger 0 " + preyManagerInst.preyHunger + preyManagerInst.FoodDetected);
        }
        else if ((collision.gameObject.tag == "Rabbit") && (this.transform.parent.tag == "Rabbit"))
        {
            // Rabbit detected by mating collider, create baby rabbit if it has been long enough since last mating
            if (preyManagerInst.preyMateTimer >= preyManagerInst.preyMateTimeCal)
            {
                if (debugLevel >= 1) print("PreyAI: prey just mated");
                Instantiate(BabyRabbitPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                preyManagerInst.preyMateTimer = 0;
            }
        }
        else if ((collision.gameObject.tag == "Beaver") && (this.transform.parent.tag == "Beaver"))
        {
            // Beaver detected by mating collider, create baby beaver if it has been long enough since last mating
            if (preyManagerInst.preyMateTimer >= preyManagerInst.preyMateTimeCal)
            {
                if (debugLevel >= 1) print("PreyAI: prey just mated");
                Instantiate(BabyBeaverPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                preyManagerInst.preyMateTimer = 0;
            }
        }
        else if ((collision.gameObject.tag == "Moose") && (this.transform.parent.tag == "Moose"))
        {
            // Moose detected by mating collider, create baby moose if it has been long enough since last mating
            if (preyManagerInst.preyMateTimer >= preyManagerInst.preyMateTimeCal)
            {
                if (debugLevel >= 1) print("PreyAI: prey just mated");
                Instantiate(BabyMoosePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                preyManagerInst.preyMateTimer = 0;
            }
        }
    }
}
