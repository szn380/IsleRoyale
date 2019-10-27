using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDetect : MonoBehaviour {
    public Transform Gore;              // reference to Gore Prefab
    public Transform BabyWolf;          // reference to BabyWolf Prefab
    public int debugLevel = 0;          // controls the amount of detail printed out for debugging (0 = no debug)      

    float wolfMatingTimer = 0;          // counter indicating how long since a wolf last mated - determines when it can mate again
    WolfMoveScript wolfMoveScriptInst;  // access variables form wolfMoveScript
    WolfManager wolfManagerInst;        // access variables from WolfManager

    private void Update()
    {
        wolfMatingTimer += Time.deltaTime;
    }

        // handle Eat / Mating game oject collisions (eat rabbits, have baby wolves)
    void OnTriggerEnter(Collider collision)
    {
        wolfManagerInst = GetComponentInParent<WolfManager>();      // get instance of WolfManager so that this script can access it variables
        wolfMoveScriptInst = GetComponentInParent<WolfMoveScript>();

        if ((collision.gameObject.tag == "Rabbit") || (collision.gameObject.tag == "BabyRabbit") || (collision.gameObject.tag == "Moose") || (collision.gameObject.tag == "BabyMoose") || (collision.gameObject.tag == "Beaver") || (collision.gameObject.tag == "BabyBeaver"))
        {
            // rabbit detected by eat collider, eat the rabbit
            wolfMoveScriptInst.WolfHunger = 0.0f;
            wolfManagerInst.wolfHungry = 0;
            wolfManagerInst.RabbitDetected = 0;
            wolfManagerInst.RabbitPosition = new Vector3(0f, 0f, 0f);
            if (debugLevel >= 1) print("EatDetect: Just Ate: Hunger 0 " + wolfMoveScriptInst.WolfHunger + wolfManagerInst.RabbitDetected);
            Instantiate(Gore, new Vector3(collision.transform.position.x, 0, collision.transform.position.z), collision.transform.rotation);
            if ((collision.gameObject.tag == "Rabbit") || (collision.gameObject.tag == "Moose") || (collision.gameObject.tag == "Beaver"))
            {
                Destroy(collision.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Wolf")
        {
            // wolf detected by mating collider, create baby wolf if it has been long enough since last mating
            if (wolfManagerInst.wolfMateTimer >= wolfManagerInst.wolfMateTimeCal)
            {
                if (debugLevel >= 1) print("WolfAI: wolf just mated");
                Instantiate(BabyWolf, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                wolfManagerInst.wolfMateTimer = 0;
            }
        }
    }
}
