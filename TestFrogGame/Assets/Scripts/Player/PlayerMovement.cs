using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float jumpForce = 10;
    public bool isJumping = false;
    private bool isGrounded;
    float startTime = 0f; // Variable to store the start time of the input
    [SerializeField]  private float speed;
    [SerializeField] public Collider2D Ground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Ground Check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == Ground) { 
            Debug.Log("on ground"); 
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider == Ground) {
            Debug.Log("off ground"); 
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed,body.linearVelocity.y);
        
        if(Input.GetKey(KeyCode.Space) & isJumping == false){
            // we want to store the amount of time they hold the space bar and apply the force when it is released
            isJumping = true;
            startTime = Time.time; // Store the current time
        }

        if (isJumping == true & !(Input.GetKey(KeyCode.Space))) {
            isJumping = false;
            // compare the time to when they started holding the space bar to the time they release and jump accordingly
            Debug.Log(Time.time - startTime);
            if ((Time.time - startTime) < .2) { Debug.Log("Small Jump"); jumpForce = 5; } 
            if (((Time.time - startTime) > .2) & (Time.time - startTime) < .5) { Debug.Log("Medium Jump"); jumpForce = 7; }
            if ((Time.time - startTime) > .5) { Debug.Log("Large Jump"); jumpForce = 10; }
            if (isGrounded) { body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce); }
        }

    }
}
