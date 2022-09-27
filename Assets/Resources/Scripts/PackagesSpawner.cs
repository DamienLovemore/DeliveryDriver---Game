using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackagesSpawner : MonoBehaviour
{
    private GameObject spawnsContainer;
    private GameObject customersContainer;
    [SerializeField] private GameObject packagesContainer;
    [SerializeField] private GameObject packageTemplate;

    void Start()
    {
        //Picks the container for game objects
        spawnsContainer = GameObject.Find("SpawnPoints");
        customersContainer = GameObject.Find("Customers");
        //Creates one package to be delivered (zero per default)
        CreateNewPackage();
    }

    //Creates a new package in a random position, and color for the game.
    //(Also attaches it to the correct parent for layout readability)
    public void CreateNewPackage()
    {
        //Gets the new package position to be placed
        Vector3 packagePosition = getNewSpawnPosition();
        //Gets the new package color to be renderized
        Color packageColor = getNewPackageColor();

        //Creates a new package
        GameObject createdPackage = Instantiate(packageTemplate, packagePosition, Quaternion.identity);
        //Changes the package color to match the generated color
        createdPackage.GetComponent<SpriteRenderer>().color = packageColor;
        //Sets its layout to be inside the packagesContainer (Avoid layout pollution)
        createdPackage.transform.SetParent(packagesContainer.transform);
    }

    //Gets a random color for this new package to be, that matches
    //the color of a random existing customer.
    private Color getNewPackageColor()
    {
        Color packageColor;

	    //Generate randomly a number between 0 and length-1 the
        //number of Customers we have
        int randomCustomer = Random.Range(0, 8);

	    SpriteRenderer customerRenderer = customersContainer.transform.GetChild(randomCustomer).GetComponent<SpriteRenderer>();
	    packageColor = customerRenderer.color;

        return packageColor;
    }

    //Gets a random spawn point position for the new package
    //to be placed
    private Vector3 getNewSpawnPosition()
    {
        Vector3 spawnPosition;

        //Generate randomly a number between 0 and length-1 the
        //number of SpawnPoints we have
        int randomPosition = Random.Range(0, 8);

        Transform spawnPoint = spawnsContainer.transform.GetChild(randomPosition);
        spawnPosition = spawnPoint.position;

        return spawnPosition;
    }
}
