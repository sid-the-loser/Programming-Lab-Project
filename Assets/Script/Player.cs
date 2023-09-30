using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int speed; // player speed variable

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
        transform.transform.position += mov_dir * (speed * Time.deltaTime); // changes the direction
    }

    public void Jump() // Jump function, we did work on it in this weeks tutorial, but thats on a different project
    {
        Debug.Log("I jumped!");
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
}
