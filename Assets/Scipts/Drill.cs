using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public Animator animator;
    public float yOffset;

    void Start()
    {
        animator.SetTrigger("drillanddrillbittrig");
        transform.Translate(new Vector3(0, yOffset, 0));
    }

    
}
