using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {    

    public GameObject playerPrefab;
        //Variable GameObject for our playerPrefab (can be changed in unity)

    GameObject playerInstance;
        //Variable GameObjects for playerInstance (putting the player in the game)

    public int numLives = 4;
        //Variable intiger for player lives (can be changed in unity)

    private float currentHealth;
        //Varible float to show current player health

    public GUISkin MaxGUISkin;
        //Variable for GUISkin (mad max)

    float respawnTimer;
        //Variable float for controlling repsawn time

    bool gamePause;
        //Variable bool it let us know if the game is paused

    DamageHandler damageHandler;
        //Variable DamageHandler for getting health

    //EnemySpawner enemySpawner;
    //Variable EnemySpawner for enemy count

    //private float currentEnemy;
    //Variable for current number of enemies

    void Start ()
    {
        SpawnPlayer();
            //Spawn the player (on start) 
	}


    //  vvvvv   Spawning The Player vvvvv //
    void SpawnPlayer()
    {
        Debug.Log("Player has been spawned!");
            //Debug message

        numLives--;
            //Subtract from the player life counter

        respawnTimer = 1;
            //Set our respawn timer to 1

        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
            //Create a PlayerCar instance from prefab

        playerInstance.name = "PlayerCar";
            //Name our player PlayerCar

        damageHandler = playerInstance.GetComponent<DamageHandler>();
        //Set up DamageHandler

        //enemySpawner = GetComponent<EnemySpawner>();
        //Set up enemyspawner

    }

    void Update ()
    {

        gamePause = PauseMenu.gameIsPaused;
        //Check if game is paused


        if (playerInstance == null)
        {
            respawnTimer -= Time.deltaTime;
            //Subtract time from respawn timer if player is dead

            if (respawnTimer <= 0 && numLives > 0)
            {
                SpawnPlayer();
                //Respawn player if lives remain and respawn timer ends
            }

        }

        damageHandler = playerInstance.GetComponent<DamageHandler>();
        //Get damagehandler from player

        currentHealth = damageHandler.health;
        //Get players current health

        //enemySpawner = GetComponent<EnemySpawner>();
        //Set up enemyspawner

        //currentEnemy = enemySpawner.currentEnemyCount;
        //Get current number of enemies

    }

    void OnGUI()
    {

        GUI.skin = MaxGUISkin;
        //Change GUISkin

        GUI.color = Color.black;
        //Change GUI color to black

        if (numLives > 0 || playerInstance != null || !gamePause)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives: " + numLives);
            //Display number of lives (if player is alive and game isn't paused)
            GUI.Label(new Rect(0, 15, 100, 50), "Health: " + currentHealth);
            //Dislay current health
            //GUI.Label(new Rect(0, 30, 100, 50), "Enemies: " + currentEnemy);
            //Dislay current health
        }

        else if (numLives <= 0 || !gamePause)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "GAME OVER!");
            //Display game over if player is dead
        }

        else if (gamePause)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Game Paused");
            //Change label to "Game paused" on game pause
        }

    }
}
