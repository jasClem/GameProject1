using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform myTarget;
        //Transform variable to change myTarget for camera to follow (can be changed in unity)

    void Update () {

        if (myTarget == null)
            //Check if myTarget doesn't exist
        {
            GameObject go = GameObject.FindWithTag("Player");
                //Variable for Player's GameObject (Find Tag)
            
            //GameObject go = GameObject.Find("PlayerCar");     <-EXTRA(alternative)
                //Variable for PlayerCar GameObject (Find Object by Name)

            if (go != null)
                //Check for go (GameObject)
            {
                myTarget = go.transform;
                    //Set myTarget to our go (GameObject)
            }

        }

        if (myTarget != null)
            //Check if myTarget exists
        {
            Vector3 targetPos = myTarget.position;
                //Variable for Vector3 targetPos from myTarget position

            targetPos.z = transform.position.z;
                //Change targetPos's z position

            //Vector3.Lerp =    <- EXTRA
                //Lerp <- more info needed

            transform.position = targetPos;
                //Change position to targetPos

        }
	}
}
