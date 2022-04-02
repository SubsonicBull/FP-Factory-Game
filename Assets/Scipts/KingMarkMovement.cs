using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMarkMovement : MonoBehaviour
{

    public Rigidbody rb;

    public GameObject wtl;
    public GameObject KingMark;
    public GameObject sprite;

    public Quaternion wtl_r;
    
    Vector3 velocity;
    
    public int speed;

    void Start()
    {
        speed = 0;
        transform.LookAt(wtl.transform);
    }
    
    void Update()
    {
        if(Input.GetKeyUp("k"))
        {
            rb.drag = 5;
        }

        if(Input.GetKey("k"))
        {
            rb.drag = 0;
            transform.LookAt(wtl.transform);
            speed = 3000;
            Vector3 move = transform.forward;
            rb.AddForce(move * speed * Time.deltaTime);
        }
    }
}