using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    //Assigned to bullets (how long will bullets go on for?)

    public float timer = 3f;
        //Float variable for timer (can be changed in unity)

	void Update ()
    {
        timer -= Time.deltaTime;
            //Countdown timer

        if (timer <= 0)
                //Check if timer hits 0
        {
            Destroy(gameObject);
                //Destroy current gameObject
        }
	}
}
