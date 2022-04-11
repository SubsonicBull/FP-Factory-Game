using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    public bool in_range;

    void Start()
    {
        in_range = false;
    }

    void OnTriggerEnter()
    {
        in_range = true;
    }

    void OnTriggerExit()
    {
        in_range = false;
    }
}
