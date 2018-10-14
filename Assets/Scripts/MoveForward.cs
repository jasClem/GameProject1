using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    public float maxSpeed = 8f;
    //Float variable for maximum speed (can be changed in unity)
	

	void Update ()
    {
        Vector3 pos = transform.position;
        //Vector3 variable to track current car position

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        //Vector3 variable for velocity (max speed * time)

        pos += transform.rotation * velocity;
        //Add velocity * current rotation to position

        transform.position = pos;
        //Update car to current position
    }
}
