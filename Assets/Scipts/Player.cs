﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public float speed;
    public float gravity;
    public float gridsize = 10;
    public float distancetoground;
    public CharacterController crcon;
    public Transform groundcheck;
    public Transform cam;
    public LayerMask ground;
    Vector3 velocity;
    bool isGrounded;    
    int selectediventorySlot;    
    RaycastHit hit;    
    Vector3 calculatedGridPos;
    public Image[] inventorySlots = new Image[5];
    public GameObject[] placableObjects = new GameObject[5];


    private void Start()
    {
        selectediventorySlot = 0;
        inventorySlots[selectediventorySlot].color = new Color(255, 255, 255);
    }

    void Update()
    {
        //movement

        isGrounded = Physics.CheckSphere(groundcheck.position, distancetoground, ground);

        if(isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        crcon.Move(move * speed * Time.deltaTime);
        crcon.Move(velocity);

        //Inventory

        if (Input.GetKeyDown("f"))
        {
            if (selectediventorySlot == 4)
            {
                inventorySlots[selectediventorySlot].color = new Color(0, 0, 0);
                selectediventorySlot = 0;
                inventorySlots[selectediventorySlot].color = new Color(255, 255, 255);
            }
            else
            {
                inventorySlots[selectediventorySlot].color = new Color(0, 0, 0);
                selectediventorySlot += 1;
                inventorySlots[selectediventorySlot].color = new Color(255, 255, 255);
            }
        }

        //PlacementSystem

        
        if (Input.GetButtonDown("Fire1"))
        {            
            
            if (Physics.Raycast(cam.transform.position, cam.transform.forward,out hit, 20, ground))
            {                               
                calculatedGridPos = new Vector3(Mathf.Floor(hit.point.x / gridsize) * gridsize + gridsize/2,1.5f, Mathf.Floor(hit.point.z / gridsize) * gridsize + gridsize / 2);
                Instantiate(placableObjects[selectediventorySlot], calculatedGridPos, Quaternion.Euler(0f, 0f, 0f));                
            }
        }
        
    }
}
