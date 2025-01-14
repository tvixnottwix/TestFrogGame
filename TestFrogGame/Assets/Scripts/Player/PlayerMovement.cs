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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
        
        
        //             
        // Ground Check
        void OnCollisionEnter(Collision col) {
            if (col.gameObject.name == "Ground") {
                isGrounded = true;
            }
        }
        void OnCollisionExit(Collision col) {
            if (col.gameObject.name == "Ground") {
                isGrounded = false;
            }
        }

    }
}
