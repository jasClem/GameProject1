using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
        //

    public GameObject pauseMenuUi;
        //GameObject variable for Pause Menu UI


	void Update () {

        if (Input.GetButtonDown("Cancel"))
            //Check if player is pressing "Cancel" button (assigned in unity)
        {
            if (gameIsPaused)
                //Check if gameIsPaused is true (Is the game paused?)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
		
	}

    public void Resume()
    {
        Debug.Log("Game Resumed!");
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        Debug.Log("Game Is Paused!");
            //Debug message

        pauseMenuUi.SetActive(true);
            //Turn on Pause Menu UI

        Time.timeScale = 0f;
            //Stop game time.

        gameIsPaused = true;
            //Change pause bool
    }

    public void LoadMenu()
    {
        Debug.Log("Load Main Menu!");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        gameIsPaused = false;

    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();

    }
}
