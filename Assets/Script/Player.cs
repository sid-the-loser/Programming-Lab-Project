using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Player : MonoBehaviour
{
    [SerializeField] float speed; // player speed variable
    [SerializeField] float jump_speed; // player jump speed variable, for the next assignment

    [SerializeField] int score; // score of the player

    bool is_grounded = false; // checks if player is grounded

    Quaternion locked_rotation;

    Rigidbody rb; // rigid body stuff, this is for the next assignment

    Vector3 mov_dir; // Vector to identify which direction the player should move in

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this); // Function called to initiate InputManager
        InputManager.GameMode(); // Function called to enable GameMode controls and disabling UI controls

        rb = GetComponent<Rigidbody>(); // this is for the next assignment
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = locked_rotation; // locking the direction so i can check ground better

        is_grounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1);
        /*
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1))
        {
            is_grounded = true;
        }
        else
        {
            is_grounded = false;
        }
        */

        transform.position += mov_dir * (speed * Time.deltaTime); // changes the direction
    }

    public void Jump()
    {
        if (is_grounded)
        {
            rb.AddForce(Vector3.up * jump_speed, ForceMode.Impulse);
        }
    }

    public void Crouch() // Crouch function to be worked on later
    {
        Debug.Log("I crouched!");
    }

    public void setMoveDirection(Vector2 Direction) // working with move direction from the InputManager to the player
    {
        mov_dir.x = Direction.x; // this sin was done to fix issues between Vector2 and Vector3
        mov_dir.z = Direction.y;
    }

    void addScore() // function to add 1 to score variable (I know, its a sin, could have done it better)
    {
        score++;
    }
}
