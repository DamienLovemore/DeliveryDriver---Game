using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //Handle score and highscore information and display
    [SerializeField] ScoreManager scoreManager;
    //Handle the spawn of packages
    [SerializeField] PackagesSpawner spawnManager;
    //Stores all the packages collected (just once per time,
    //but if need to expand it is already a list)
    List<Color> packagesCollected;
    //The number of seconds to await before destroying the package
    [SerializeField] float packageDelay;
    
    private void Start()
    {
        packagesCollected = new List<Color>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //The object that was triggered
        GameObject objectTriggered = collision.gameObject;
        //The color of the object
        Color triggeredColor = objectTriggered.GetComponent<SpriteRenderer>().color;

        // Can only collect packages if it did not collect one already.
        // Stores the color of the package collected, so it can only
        // be delivered to the right customer (of the same color)
        if ((collision.tag == "Package") && (hasAnyPackages() == false))
        {
            packagesCollected.Add(triggeredColor);
            Destroy(collision.gameObject, packageDelay);            
        }
        else if ((collision.tag == "Customer") && (hasPackageWithColor(triggeredColor)))
        {
            packagesCollected.Remove(packagesCollected[packagesCollected.Count - 1]);
            scoreManager.IncreaseScore();
            spawnManager.CreateNewPackage();
        }
    }

    //Returns true if the delivery car has collected a package with
    //the same color as the customer is is trying to deliver to.
    private bool hasPackageWithColor(Color customerColor)
    {
        bool hasRightPackage = false;

        foreach (var packageColor in packagesCollected)
        {
            if (packageColor.Equals(customerColor))
            {
                hasRightPackage = true;
                break;
            }                
        }

        return hasRightPackage;
    }

    //Returns true if there is at least one package collected by this
    // delivery car. false otherwise.
    private bool hasAnyPackages()
    {
        bool hasPackage = false;

        if (packagesCollected.Count > 0)
            hasPackage = true;

        return hasPackage;
    }
}
