using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    public float health = 10;
    //Float variable for health (can be changed in unity)

    public float invulnrablePeriod = 1;
    //Float variable for invulnrable period (seconds) (can be changed in unity)

    float invulnrableTimer = 0;
    //Float variable for 

    int correctLayer;
    //Float invAniTimer = 0;

    SpriteRenderer spriteRend;
    //SpriteRenderer variable

    ///float gasTank = 100; <-Unused


    void Start()
    {
        correctLayer = gameObject.layer;
        //Get game object's current layer

        spriteRend = GetComponent<SpriteRenderer>();
        //Get sprite

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
            //Get child component in children if no sprite found

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite rendered.");
                //Display debug message if no sprites found.
            }
        }
    }

    void OnCollisionEnter2D()
    {
        Debug.Log("Collision Detected!");
        //Display debug message for colisions (aka car on car)

        if (invulnrablePeriod > 0)
        {
            invulnrableTimer = invulnrablePeriod;
            //Change invulnrable timer to invulnrable period if collision detected

            gameObject.layer = 10;
            //Move game object to layer 10 (aka invulnrable layer)

        }

        if (invulnrableTimer <= 0)
        {
            health--;
            //Subtract health if invulnrable timer is 0
        }

        else
        {

        }

    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger Detected!");
        //Display debug message for triggers (aka bullets)


        if (invulnrablePeriod > 0)
        {
            invulnrableTimer = invulnrablePeriod;
            //Change invulnrable timer to invulnrable period if collision detected

            gameObject.layer = 10;
            //Move game object to layer 10 (aka invulnrable layer)

        }

        if (invulnrableTimer >= 0)
        {
            health--;
            //Subtract health if invulnrable timer is 0
        }

        else
        {
            
        }

    }

    void Update()
    {
        
        if (invulnrableTimer > 0)
        {
            invulnrableTimer -= Time.deltaTime;
            //Subtract time from invulnrable timer if timer is greater than 0

            if (invulnrableTimer <= 0)
            {
                gameObject.layer = correctLayer;
                //Move game object back to correct layer if invulnrable timer is less than 0

                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                    //Flash Sprite to show invulnrable period if sprite is found
                }


            }
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                    //Flash Sprite to show invulnrable period is sprite is found
                }
            }
            
        }

        if (health <= 0)
        {
            Die();
            //Kill player if health is less than 0
        }
    }

    void Die()
    {
        Destroy(gameObject.gameObject);
        //Destroy game object (kill player or enemy)
    }
}
