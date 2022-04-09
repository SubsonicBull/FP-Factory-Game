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
    public float jumpheight;
    public CharacterController crcon;
    public Transform groundcheck;
    public Transform cam;
    public GameObject cantPlaceHereText;
    public GameObject flashlight;
    public GameObject buildUI;
    public LayerMask ground;
    public bool buildmode;
    Vector3 velocity;
    bool isGrounded;    
    int selectediventorySlot;    
    RaycastHit hit;       
    Vector3 calculatedGridPos;
    public Image[] inventorySlots = new Image[5];
    public GameObject[] placableObjects = new GameObject[5];
    GameObject lastInstantiatedObject;
    List<Vector3> positionsOfPlacedObjects = new List<Vector3>();


    private void Start()
    {
        selectediventorySlot = 0;
        inventorySlots[selectediventorySlot].color = new Color(255, 255, 255);
        cantPlaceHereText.SetActive(false);
        flashlight.SetActive(false);
        buildmode = false;
        buildUI.SetActive(false);
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
        if (Input.GetKey("space") && isGrounded)
        {            
                velocity = new Vector3(0, jumpheight, 0);            
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        crcon.Move(move * speed * Time.deltaTime);
        crcon.Move(velocity);

        //Inventory

        if (Input.GetKeyDown("f"))
        {
            if(buildmode == true)
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
        }

        //PlacementSystem

        if (Input.GetButtonDown("Fire1"))
        {
            if(buildmode == true)
            {                        
                if (Physics.Raycast(cam.transform.position, cam.transform.forward,out hit, 20, ground))
                {                                    
                    calculatedGridPos = new Vector3(Mathf.Floor(hit.point.x / gridsize) * gridsize + gridsize / 2, 1.5f, Mathf.Floor(hit.point.z / gridsize) * gridsize + gridsize / 2);
                    if (!positionsOfPlacedObjects.Contains(calculatedGridPos))
                    {
                        if (selectediventorySlot != 3)
                        {
                            lastInstantiatedObject = Instantiate(placableObjects[selectediventorySlot], calculatedGridPos, Quaternion.Euler(0f, 0f, 0f));
                            positionsOfPlacedObjects.Add(lastInstantiatedObject.GetComponent<Transform>().position);
                        }
                        else
                        {
                            if (!positionsOfPlacedObjects.Contains(calculatedGridPos + new Vector3(gridsize, 0, 0)))
                            {
                                lastInstantiatedObject = Instantiate(placableObjects[selectediventorySlot], calculatedGridPos, Quaternion.Euler(0f, 0f, 0f));
                                positionsOfPlacedObjects.Add(lastInstantiatedObject.GetComponent<Transform>().position);
                                positionsOfPlacedObjects.Add(lastInstantiatedObject.GetComponent<Transform>().position + new Vector3(gridsize, 0, 0));           
                            }
                            else
                            {
                                cantPlaceHereText.SetActive(true);
                                Invoke("CantPlaceTextMethod", 2.0f);
                            }
                        }
                    }
                    else
                    {
                        cantPlaceHereText.SetActive(true);
                        Invoke("CantPlaceTextMethod", 2.0f);
                    }
                }
            }
        }
        
        if(Input.GetKeyDown("q"))
        {
            if(buildmode == true)
            {
                buildmode = false;
                buildUI.SetActive(false);
            }
            else
            {
                buildmode = true;
                buildUI.SetActive(true);
            }
        }
        
        if (Input.GetKeyDown("t"))
        {
            foreach (Vector3 vector3 in positionsOfPlacedObjects)
            {
                Debug.Log(vector3);
            }
        }

        if (Input.GetKeyDown("b"))
        {
            if(flashlight.activeSelf == true)
            {
                flashlight.SetActive(false);
            }
            else
            {
                flashlight.SetActive(true);
            }

        }
    }
    void CantPlaceTextMethod()
    {
        cantPlaceHereText.SetActive(false);
    }
}
