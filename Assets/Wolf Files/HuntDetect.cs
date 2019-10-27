using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntDetect : MonoBehaviour {

    public int debugLevel = 0;          // controls level of detail of debug info (0 = no debug info)


    void OnTriggerEnter(Collider collision)
    {
        WolfManager wolfManagerInst;

        wolfManagerInst = GetComponentInParent<WolfManager>();      // get instance of WolfManager so that this script can access it variables

        if ((wolfManagerInst.RabbitDetected == 0) && (wolfManagerInst.WolfMateDetected == 0))
        {
            if (debugLevel >= 2) print("HuntDetec: Detected Something");
            if ((collision.gameObject.tag == "Rabbit") || (collision.gameObject.tag == "BabyRabbit") || (collision.gameObject.tag == "Moose") || (collision.gameObject.tag == "BabyMoose") || (collision.gameObject.tag == "Beaver") || (collision.gameObject.tag == "BabyBeaver"))
            {
                if (wolfManagerInst.wolfHungry == 1)
                {
                    if (debugLevel >= 1) print("HuntDetect: Detected Rabbit, Start Hunt");
                    wolfManagerInst.RabbitPosition = collision.transform.position;
                    wolfManagerInst.RabbitDetected = 1;
                }
            } 
            else if (collision.gameObject.tag == "Wolf" )
            {
                if (wolfManagerInst.wolfMateTimer >= wolfManagerInst.wolfMateTimeCal)
                {
                    wolfManagerInst.WolfMatePosition = collision.transform.position;
                    wolfManagerInst.WolfMateDetected = 1;
                }
            }
            
        }
    }

    void OnTriggerStay(Collider collision)
    {
        WolfManager wolfManagerInst;

        wolfManagerInst = GetComponentInParent<WolfManager>();      // get instance of WolfManager so that this script can access it variables

        if ((wolfManagerInst.RabbitDetected == 0) && (wolfManagerInst.WolfMateDetected == 0))
        {
            if (debugLevel >= 2) print("HuntDetec: Detected Something");
            if ((collision.gameObject.tag == "Rabbit") || (collision.gameObject.tag == "BabyRabbit") || (collision.gameObject.tag == "Moose") || (collision.gameObject.tag == "BabyMoose") || (collision.gameObject.tag == "Beaver") || (collision.gameObject.tag == "BabyBeaver"))
            {
                if (wolfManagerInst.wolfHungry == 1)
                {
                    if (debugLevel >= 1) print("HuntDetect: Detected Rabbit, Start Hunt");
                    wolfManagerInst.RabbitPosition = collision.transform.position;
                    wolfManagerInst.RabbitDetected = 1;
                }
            }
            else if (collision.gameObject.tag == "Wolf")
            {
                if (wolfManagerInst.wolfMateTimer >= wolfManagerInst.wolfMateTimeCal)
                {
                    wolfManagerInst.WolfMatePosition = collision.transform.position;
                    wolfManagerInst.WolfMateDetected = 1;
                }
            }
        }
    }
}



