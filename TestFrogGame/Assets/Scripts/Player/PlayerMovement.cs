using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
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
            body.linearVelocity = new Vector2(body.linearVelocity.x,speed/3);
        }
    }
}
