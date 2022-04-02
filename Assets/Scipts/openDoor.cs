using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{

    public CheckCollision checkCollision;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkCollision.count_collectedItems == 1)
        {
            animator.SetTrigger("AllCollectables");
        }
    }
}
