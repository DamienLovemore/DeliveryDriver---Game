using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject PlayerCar;
    
    // Change the camera position to be the same as the car`s position
    private void LateUpdate()
    {
        transform.position = PlayerCar.transform.position + new Vector3(0,0,-10);
        transform.LookAt(PlayerCar.transform.position);
    }
}
