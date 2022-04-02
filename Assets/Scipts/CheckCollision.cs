using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{

    public hitboxTrigger hitboxTrigger;

    public GameObject plant_b01;

    public bool collision_check;

    public int count_collectedItems;

    void Start()
    {
        count_collectedItems = 0;
    }

    void Update()
    {
        if(collision_check == true && Input.GetKeyDown("e"))
        {
            plant_b01.SetActive(false);
            count_collectedItems = count_collectedItems +1;
        }
    }
}
