using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 0.01f;       

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Increase proportionally to the speed defined
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        // Makes it moves the same per second, independentlly of the computer
        steerAmount *= Time.deltaTime;
        moveAmount *= Time.deltaTime;

        // To make it rotate to the right direction we need to invert the values
        // (Just for the rotation)
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
