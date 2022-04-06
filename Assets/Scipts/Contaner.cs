using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contaner : MonoBehaviour
{
    public Vector3 offset;
    
    void Start()
    {
        transform.Translate(offset);
    }
}
