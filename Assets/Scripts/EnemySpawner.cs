using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    //GameObeject variable for enemy prefab (can be assigned in unity)

    public float maxEnemyCount = 50;
    //Float variable for max number of enemies (can be changed in unity)

    float spawnDistance = 12f;
    //Float variable for spawn distance

    float enemyRate = 5;
    //Float variable for enemy rate

    float enemyTimer = 1;
    //Float variable for enemy timer

    public float currentEnemyCount = 0;
    //Float variable for current emeny count

    public Transform myTarget;
	
	void Update ()
    {

        if (myTarget == null)
        {
            GameObject playerCar = GameObject.FindWithTag("Player");
            //Find player car GameObject

            if (playerCar != null)
            {
                myTarget = playerCar.transform;
                //Set enemy target to player car if not already
            }

        }

        enemyTimer -= Time.deltaTime;

        if (enemyTimer <= 0 && myTarget != null && currentEnemyCount < maxEnemyCount)
        {
            enemyTimer = enemyRate;
            //Set enemy timer to enemy rate

            enemyRate *= 0.1f;
            //Increase enemy rate by *.1

            if (enemyRate < 1)
            {
                enemyRate = 1;
                //Set enemy rate to 1 if less than 1
            }

            Vector3 offset = Random.onUnitSphere;
            //Set up spawn area offset

            offset.z = 0;
            offset = offset.normalized * spawnDistance;

            Instantiate(enemyPrefab, myTarget.position + offset, Quaternion.identity);
            //Spawn Enemy

            Debug.Log("Enemy # " + currentEnemyCount + " Spawned!");
            //Display debug message for enemy spawn

            currentEnemyCount++;
            //Add to current enemy count

        }
	}
}
