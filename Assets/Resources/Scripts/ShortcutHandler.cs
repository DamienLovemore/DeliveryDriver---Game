using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutHandler : MonoBehaviour
{
    private GameObject textGameDescription;
    private GameObject textStart;
    private GameObject btnExitGame;
    private bool isPaused;

    // The game starts paused by default, for the player to read the 
    // game description and know what to do
    void Start()
    {
        Time.timeScale = 0;
        isPaused = true;

        textGameDescription = GameObject.Find("textGameDescription");
        textStart = GameObject.Find("textStart");
        btnExitGame = GameObject.Find("btnExitGame");
    }

    //Listen for keys corresponding to shortcuts that the player
    //might press in the gameplay
    void Update()
    {
        // ENTER -> Pause/Unpause
        if(Input.GetKeyDown(KeyCode.Return))
        {            
            togglePauseGame();
        }
        // ESC -> Exits the game
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        // F11 -> Toggle fullscreen ON/OFF
        else if(Input.GetKeyDown(KeyCode.F11))
        {
            FullScreenMode actualScreenMode = Screen.fullScreenMode;

            if ((actualScreenMode == FullScreenMode.Windowed) || (actualScreenMode == FullScreenMode.MaximizedWindow))
            {
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            }
            else
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }
        }
    }

    //If the game is playing pause it, and if it is not make it run again
    private void togglePauseGame()
    {
        if (isPaused)
        {
            //Resumes the game
            Time.timeScale = 1;

            //Hide the elements in the pause HUD
            textGameDescription.SetActive(false);
            textStart.SetActive(false);
            btnExitGame.SetActive(false);
            isPaused = false;
        }            
        else
        {
            //Pauses the game
            Time.timeScale = 0;

            //Show the elements in the pause HUD
            textGameDescription.SetActive(true);
            textStart.SetActive(true);
            btnExitGame.SetActive(true);
            isPaused = true;
        }
    }
}
