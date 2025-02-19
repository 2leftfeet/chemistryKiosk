﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Animator animator;
    public int playerNumber = 0;
    public float movementSpeed = 10f;
    [SerializeField]
    GameObject movingAvatar;
    Rigidbody movingAvaterRB;

    //TODO:
    // get where to look
    // move from there
    private string horizontalName = "Horizontal";
    private string verticalName = "Vertical";

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        // THIS IS FOR DEBUGING DONT FORGET TO DELETE

        //horizontalName += playerNumber;
        //verticalName += playerNumber;


        // remove this for multiplayer????
        movingAvatar = gameObject;

        if(movingAvatar)
            movingAvaterRB = movingAvatar.GetComponent<Rigidbody>();
    }


    public void SetPlayerNumber(int number)
    {
        playerNumber = number;
        horizontalName += number.ToString();
        verticalName += number.ToString();
        gameObject.GetComponentInChildren<ItemManager>().SetPlayerNumber(number);
    }

    //private shieieeet
    float horizontalAxis;
    float verticalAxis;
    public Vector3 movementDirection;
    public Vector3 movementDirectionalSpeed;

    Vector3 Gohere;

    void Update()
    {
        //dah
        horizontalAxis = Input.GetAxis(horizontalName);
        verticalAxis = Input.GetAxis(verticalName);


        movementDirectionalSpeed.x = horizontalAxis;
        movementDirectionalSpeed.y = 0;
        movementDirectionalSpeed.z = verticalAxis;


        // get direction and normalize it
        movementDirection = Vector3.Normalize(movementDirectionalSpeed);
        Gohere = Vector3.Lerp(transform.forward, movementDirection, 0.3f);
        LookThere(Gohere);

        if (movementDirectionalSpeed.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
            if (movementDirectionalSpeed.magnitude >= 1)
                MoveObject(movementSpeed * 1, movementDirection);   // 1 is maximum magnitude 
            else
                MoveObject(movementSpeed * movementDirectionalSpeed.magnitude, movementDirection);
        }else
            animator.SetBool("isWalking", false);



    }

    void LookThere(Vector3 direction)
    {
        Vector3 pointToLookAt = movingAvatar.transform.position + direction;
        movingAvatar.transform.LookAt(pointToLookAt);

    }
    void MoveObject(float _speed, Vector3 _direction)
    {
        movingAvaterRB.velocity = _direction * _speed;
        //movingAvaterRB.AddForce(_direction * _speed);
        
    }
}
