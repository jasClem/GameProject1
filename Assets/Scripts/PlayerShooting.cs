using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bulletPrefab;
        //Variable GameObject for our bulletPrefab (can be changed in unity)

    public float fireDelay = 0.25f;
        //Variable float to control fire delay

    int bulletLayer;
        //Variable intiger for bullet layer

    float cooldownTimer = 0;
        //Variable float for cooldown timer

	void Start ()
    {
        bulletLayer = gameObject.layer;
            //Set bullet layer intiger to current object layer (on start)
	}
	
	void Update ()
    {
        Vector3 bulletRot = transform.rotation.eulerAngles;
            //Variable Vector3 for bullet rotation

        cooldownTimer -= Time.deltaTime;
            //Subtract time from the cooldown timer

        ///float hShootingInput = Input.GetAxis("Hfire");

        ///float vShootingInput = Input.GetAxis("Vfire");

        ///Vector2 shootingAngle = new Vector2(hShootingInput, vShootingInput);

        if (Input.GetButton("Vfire") && cooldownTimer <= 0)
        {

            if (Input.GetAxis("Vfire") == 1)
            {
                Debug.Log("Player is Shooting Forward!");
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * new Vector3( 0, .5f, 0);

                GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                bulletGo.layer = bulletLayer;
            }

            if (Input.GetAxis("Vfire") == -1)
            {
                Debug.Log("Player is Shooting Backward!");
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * new Vector3( 0, -.5f, 0);

                bulletRot = new Vector3(bulletRot.x, bulletRot.y, bulletRot.z +180);


                GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, Quaternion.Euler(bulletRot));
                bulletGo.layer = bulletLayer;
            }

        }

        if (Input.GetButton("Hfire") && cooldownTimer <= 0)
        {

            if (Input.GetAxis("Hfire") == 1)
            {
                Debug.Log("Player is Shooting Right!");
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * new Vector3( .5f, .5f, 0);

                bulletRot = new Vector3(bulletRot.x, bulletRot.y, bulletRot.z - 90);

                

                GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, Quaternion.Euler(bulletRot));
                bulletGo.layer = bulletLayer;
            }

            if (Input.GetAxis("Hfire") == -1)
            {
                Debug.Log("Player is Shooting Left!");
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * new Vector3( -.5f, .5f, 0);

                bulletRot = new Vector3(bulletRot.x, bulletRot.y, bulletRot.z + 90);


                GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, Quaternion.Euler(bulletRot));
                bulletGo.layer = bulletLayer;
            }


        }


    }
}
