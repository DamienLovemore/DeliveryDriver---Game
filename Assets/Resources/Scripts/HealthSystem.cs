using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private float health;
    [SerializeField] private Slider healthIndicator;

    void Start()
    {
        //Sets the initial health of the player
        health = 100.0f;
        //Sets the max value and the current value
        //of the health indicator in its full HP
        healthIndicator.maxValue = health;
        healthIndicator.value = health;
    }

    //Verifies in the background if the user still have health remaining.
    //When it does not have health anymore, the game will end
    void Update()
    {
        //When the player dies reset the game, and show the highscore
        //in the pause menu
        if (health == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Damages the user by a given amount of health points
    public void DamagePlayer(float healthPoints)
    {
        Debug.Log("I was called");
        //Instead of applying the damage directly, calculate it
        //in a separate variable for verification purposes
        float newHealth;

        newHealth = health - healthPoints;
        //If after the damage applied the health would go negative,
        //sets it to be 0 again
        if (newHealth < 0)
            newHealth = 0.0f;

        //Sets the player new health
        health = newHealth;
        healthIndicator.value = health;
        Debug.Log(healthIndicator.value);
    }

    //Damages the user by a given percentage amount of its health
    public void DamagePlayerWithPercentage(float healthPercentage)
    {
        //Instead of applying the damage directly, calculate it
        //in a separate variable for verification purposes
        float newHealth;

        float damageSuffered = Mathf.Round((healthPercentage / 100) * health);
        newHealth = health - damageSuffered;
        //If after the damage applied the health would go negative,
        //sets it to be 0 again
        if (newHealth < 0)
            newHealth = 0.0f;

        //Sets the player new health
        health = newHealth;
        healthIndicator.value = health;
    }
}
