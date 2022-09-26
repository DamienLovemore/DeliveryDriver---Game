using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI textScore;
    private TextMeshProUGUI textHighscore;
    private int gameScore;
    private int gameHighscore;

    //Sets the default values for the scores
    void Start()
    {
        //Sets the actual score to be zero, because the game has just started
        gameScore = 0;
        //Try to get the value in the settings, if there is no value
        //then returns the second argument
        gameHighscore = PlayerPrefs.GetInt("playerHighscore", 0);

        //Get the HUD text elements that will have their values updated.
        //(So we get just use, and do not have to find them every time)
        textScore = GameObject.Find("textScore").GetComponent<TextMeshProUGUI>();
        textHighscore = GameObject.Find("textHighscore").GetComponent<TextMeshProUGUI>();
        //Display the actual highscore value
        textHighscore.text = $"Highscore: {gameHighscore}";
    }

    //Increases the game score if it has delivered
    //succesfully a package
    public void IncreaseScore()
    {
        //Increases the score
        gameScore += 1;

        //Update the HUD        
        textScore.text = $"Score: {gameScore}";

        //Register the highscore the in the settings,
        //if it is a highscore
        RegisterHighscore();
    }

    //Register a highscore if the user has passed its previous value.
    private void RegisterHighscore()
    {
        if (gameScore > gameHighscore)
        {
            //Updates the actual highscore value
            gameHighscore = gameScore;
            //Save it in the settings to persists after the game
            //closes
            PlayerPrefs.SetInt("playerHighscore", gameHighscore);

            //Update the HUD
            textHighscore.text = $"Highscore: {gameHighscore}";
        }
    }
}
