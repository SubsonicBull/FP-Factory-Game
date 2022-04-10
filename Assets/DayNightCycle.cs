using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float daylength;    
    void Update()
    {
        transform.Rotate(Vector3.right, daylength * Time.deltaTime);
    }
}
