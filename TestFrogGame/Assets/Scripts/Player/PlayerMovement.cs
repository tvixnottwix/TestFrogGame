using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float jumpForce = 10;
    private bool isGrounded;
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

        if(Input.GetKey(KeyCode.Space)){
            body.linearVelocity = new Vector2(body.linearVelocity.x,jumpForce);
        }
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
