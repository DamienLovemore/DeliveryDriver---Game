using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int gameScore;
    int gameHighscore;

    //Sets the default values for the scores
    void Start()
    {
        gameScore = 0;
        //Try to get the value in the settings, if there is no value
        //then returns the second argument
        gameHighscore = PlayerPrefs.GetInt("playerHighscore", 0);
    }

    //Increases the game score if it has delivered
    //succesfully a package
    public void IncreaseScore()
    {
        TextMeshProUGUI textScore;

        //Increases the score
        gameScore += 1;

        //Update the HUD
        textScore = GameObject.Find("textScore").GetComponent<TextMeshProUGUI>();
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
        }
    }
}
