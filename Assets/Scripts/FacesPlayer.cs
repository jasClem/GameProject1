using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesPlayer : MonoBehaviour {

    public float rotSpeed = 90f;
    //Float variable for rotation speed (can be changed in unity)

    Transform myTarget;
    //Transform variable for player

	void Update ()
    {
		if (myTarget == null)
        {
            //  Find player's car   //
            GameObject go = GameObject.FindWithTag("Player");
            //GameObject variable to have enemies face toward player

            //GameObject go = GameObject.Find("PlayerCar"); <-Unused

            if (go != null)
            {
                myTarget = go.transform;
                //Move enemies toward player if player is alive
            }

        }
        
        if (myTarget == null)
        {
            return;
        }

        Vector3 playerDirection = myTarget.position - transform.position;
        //Vector3 variable to get player direction

        playerDirection.Normalize();
        //Normalize player direction

        float zAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90;
        //Float variable for z angle (rotation)

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        //Get desired rotation

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        //Rotate enemy towards player
	}
}
