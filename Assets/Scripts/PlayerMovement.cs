using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 5f;
        //Float variable for max player speed (can be changed in unity)

    public float rotSpeed = 180f;
        //Float variable for max player rotation speed (can be changed in unity)

    //float carBoundryRadius = 0.5f;    <-EXTRA(unused)
        //Float variable for car boundry radius <- For keeping player on screen bounds.

	void Start ()
    {
		//Currently unused
	}
	
	void Update () {

        Quaternion rot = transform.rotation;
            //Quaternion variable rot to track current player car rotation

        float steeringZ = rot.eulerAngles.z;
            //Float variable z to grab the euler angle (Z) from rot for car rotation

        float steeringInput = Input.GetAxis("Horizontal");
            //Float variable steering to grab inputs for "Horizontal" (input assigned in unity)


        //  vvvvv   Car steering    vvvvv   //
        if (Input.GetAxis("Vertical") != 0)
            //Check if "Vertical" input is being used (is the player giving the car some gas?)
        {
            steeringZ -= steeringInput * rotSpeed * Time.deltaTime;
            //Change the rotation of the car based on player's "Horizontal" input (Steering)

        }

        rot = Quaternion.Euler(0, 0, steeringZ);
            //Update rotation of the player's car

        transform.rotation = rot;
            //Sends rotation to rot (only if car is driving)
 

        //  vvvvv   Car gas vvvvv   //
        Vector3 pos = transform.position;
            //Vector3 variable to track current player car position

        Vector3 velocity = new Vector3 (0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
            //Vector3 variable to get player's car velocity

        pos += rot * velocity;
            //Change the position of the car based on rotation multiplied by velocity


        //if (pos.x+carBoundryRadius > Camera.main.orthographicSize)    <-EXTRA(unused)
        //{
        //    pos.x = Camera.main.orthographicSize - carBoundryRadius;
        //}
        //if (pos.x-carBoundryRadius < -Camera.main.orthographicSize)
        //{
        //    pos.x = -Camera.main.orthographicSize + carBoundryRadius;
        //}
            //For keeping player on screen boundry


        transform.position = pos;
            //Send position to car

    }
}
