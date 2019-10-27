using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDetect : MonoBehaviour
{

    public int debugLevel = 0;          // controls level of detail of debug info (0 = no debug info)


    void OnTriggerEnter(Collider collision)
    {
        PreyManager preyManagerInst;

        preyManagerInst = GetComponentInParent<PreyManager>();      // get instance of PreyManager so that this script can access it variables

        if ((preyManagerInst.FoodDetected == 0) && (preyManagerInst.preyMateDetected == 0))
        {
            if (debugLevel >= 2) print("HuntDetec: Detected Something");
            if ((collision.gameObject.tag == "LargePlant") && (this.transform.parent.tag != "Moose"))
            {
                if (preyManagerInst.preyHungry == 1)
                {
                    if (debugLevel >= 1) print("HuntDetect: Detected Rabbit, Start Hunt");
                    preyManagerInst.FoodPosition = collision.transform.position;
                    preyManagerInst.FoodDetected = 1;
                }
            }
            else if ((collision.gameObject.tag == "ExtraLargePlant") && (this.transform.parent.tag == "Moose"))
            {
                if (preyManagerInst.preyHungry == 1)
                {
                    if (debugLevel >= 1) print("HuntDetect: Detected Rabbit, Start Hunt");
                    preyManagerInst.FoodPosition = collision.transform.position;
                    preyManagerInst.FoodDetected = 1;
                }
            }
            else if ((collision.gameObject.tag == "Rabbit") && (this.transform.parent.tag == "Rabbit"))
            {
                if (preyManagerInst.preyMateTimer >= preyManagerInst.preyMateTimeCal)
                {
                    preyManagerInst.preyMatePosition = collision.transform.position;
                    preyManagerInst.preyMateDetected = 1;
                }
            }
            else if ((collision.gameObject.tag == "Beaver") && (this.transform.parent.tag == "Beaver"))
            {
                if (preyManagerInst.preyMateTimer >= preyManagerInst.preyMateTimeCal)
                {
                    preyManagerInst.preyMatePosition = collision.transform.position;
                    preyManagerInst.preyMateDetected = 1;
                }
            }
            else if ((collision.gameObject.tag == "Moose") && (this.transform.parent.tag == "Moose"))
            {
                if (preyManagerInst.preyMateTimer >= preyManagerInst.preyMateTimeCal)
                {
                    preyManagerInst.preyMatePosition = collision.transform.position;
                    preyManagerInst.preyMateDetected = 1;
                }
            }

        }
    }

    /* void OnTriggerStay(Collider collision)
    {
        PreyManager preyManagerInst;

        preyManagerInst = GetComponentInParent<PreyManager>();      // get instance of PreyManager so that this script can access it variables

        if ((preyManagerInst.FoodDetected == 0) && (preyManagerInst.preyMateDetected == 0))
        {
            if (debugLevel >= 2) print("HuntDetec: Detected Something");
            if (collision.gameObject.tag == "LargePlant")
            {
                if (preyManagerInst.preyHungry == 1)
                {
                    if (debugLevel >= 1) print("HuntDetect: Detected Rabbit, Start Hunt");
                    preyManagerInst.FoodPosition = collision.transform.position;
                    preyManagerInst.FoodDetected = 1;
                }
            }
            else if ((collision.gameObject.tag == "Rabbit") && (this.transform.parent.tag == "Rabbit"))
            {
                print("RABBIT DETECTED");
                if (preyManagerInst.preyMateTimer >= preyManagerInst.preyMateTimeCal)
                {
                    preyManagerInst.preyMatePosition = collision.transform.position;
                    preyManagerInst.preyMateDetected = 1;
                }
            }
            else if ((collision.gameObject.tag == "Beaver") && (this.transform.parent.tag == "Beaver"))
            {
                if (preyManagerInst.preyMateTimer >= preyManagerInst.preyMateTimeCal)
                {
                    preyManagerInst.preyMatePosition = collision.transform.position;
                    preyManagerInst.preyMateDetected = 1;
                }
            }
            else if ((collision.gameObject.tag == "Moose") && (this.transform.parent.tag == "Moose"))
            {
                if (preyManagerInst.preyMateTimer >= preyManagerInst.preyMateTimeCal)
                {
                    preyManagerInst.preyMatePosition = collision.transform.position;
                    preyManagerInst.preyMateDetected = 1;
                }
            }

        }
    } */
}
