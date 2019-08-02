using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{


    public float movementSpeed = 10f;
    [SerializeField]
    GameObject movingAvatar;
    Rigidbody movingAvaterRB;

    //TODO:
    // get where to look
    // move from there


    void Start()
    {
        // remove this for multiplayer????
        movingAvatar = gameObject;

        if(movingAvatar)
            movingAvaterRB = movingAvatar.GetComponent<Rigidbody>();
    }


    //private shieieeet
    float horizontalAxis;
    float verticalAxis;
    public Vector3 movementDirection;
    public Vector3 movementDirectionalSpeed;


    void Update()
    {
        //dah
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        

  

        movementDirectionalSpeed.x = horizontalAxis;
        movementDirectionalSpeed.y = 0;
        movementDirectionalSpeed.z = verticalAxis;


        // get direction and normalize it
        movementDirection = Vector3.Normalize(movementDirectionalSpeed);

        LookThere(movementDirection);

        if (movementDirectionalSpeed.magnitude > 0)
        {
            if (movementDirectionalSpeed.magnitude >= 1)
                MoveObject(movementSpeed * 1, movementDirection);   // 1 is maximum magnitude 
            else
                MoveObject(movementSpeed * movementDirectionalSpeed.magnitude, movementDirection);
        }


        
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
