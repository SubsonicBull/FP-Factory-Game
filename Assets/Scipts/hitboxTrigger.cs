using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxTrigger : MonoBehaviour
{

    public CheckCollision checkCollision;

    void Start()
    {
        checkCollision.collision_check = false;
    }
    
    void OnTriggerEnter()
    {
        Debug.Log("balls");
        checkCollision.collision_check = true;
    }
}
