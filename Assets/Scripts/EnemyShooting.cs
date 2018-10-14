using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject bulletPrefab;
    //GameObject variable for bullet prefab (can be changed in unity)

    public Vector3 bulletOffset = new Vector3(0, 1f, 0);
    //Vector3 variable for bullet offset (can be changed in unity)

    public float fireDelay = 0.5f;
    //Float variable for fire delay (can be changed in unity)

    int bulletLayer;
    //Integet variable for bullet layer

    float cooldownTimer = 0;
    //Float varible for cooldown timer

    Transform myTarget;
    //Transform variable for player


    void Start()
    {
        bulletLayer = gameObject.layer;
        //Assign bullets to current game object layer
    }

    void Update()
    {
        if (myTarget == null)
        {
            //  Find player's car   //
            GameObject go = GameObject.FindWithTag("Player");
            //GameObject variable to have enemies face toward player if not already

            //GameObject go = GameObject.Find("PlayerCar"); <-Unused

            if (go != null)
            {
                myTarget = go.transform;
                //Assign player as target
            }

        }

        cooldownTimer -= Time.deltaTime;
        //Subtract time from cooldown timer

        if (cooldownTimer <= 0 && myTarget != null && Vector3.Distance(transform.position, myTarget.position) < 3)
        {
            //  Enemy Shooting  // (check cooldown timer & check for target & distance is less than 3)

            Debug.Log("Enemy is Shooting!");
            //Display debug message for enemy shooting

            cooldownTimer = fireDelay;
            //Change cooldown timer to fire delay

            Vector3 offset = transform.rotation * bulletOffset;
            //Set up the offset from enemy direction and bullet offset

            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            //Instantiate bullet game object (shoot the bullet)

            bulletGo.layer = bulletLayer;
            //Assign bullet layer
        }
    }
}
