using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // we put information at the start
    // of a class
    public float speed = 4.5f;
    public float jumpForce = 5;
    public string hero = "Redd";
    
    // xyz coordinates
    public Vector3 direction;
    public Rigidbody playerRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("My name is " + hero);
    }

    // Physics Loop
    void FixedUpdate()
    {
        // the dot is there to access
        // a functionality of "transform"
        // transform.Translate(direction * Time.deltaTime * speed);

        Vector3 velocity = direction * speed;
        velocity.y = playerRb.linearVelocity.y;
        
        playerRb.linearVelocity = velocity;
    }

    private void OnMove(InputValue value)
    {
        // Asks the input system 
        // what keys are being pressed
        Vector2 inputValue = value.Get<Vector2>();
        direction = new Vector3(
            inputValue.x,
            0,
            inputValue.y
        );
    }

    private void OnJump(InputValue value)
    {
        // Physics.Raycast will cast a line 
        // that can hit other colliders
        // If it finds a collider, it returns true
        // If it doesn't, it returns false
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);
        if (isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}