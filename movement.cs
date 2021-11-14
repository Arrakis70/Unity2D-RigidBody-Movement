using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float speed;
    Rigidbody2D rb;
    [SerializeField] private float jumping_force;
    public bool isOnGround;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void MovingSystem()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float moveBy = h * speed;
        
        rb.velocity = new Vector2(moveBy , rb.velocity.y);
    }
    void JumpingSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(new Vector2(0, jumping_force), ForceMode2D.Impulse);
            isOnGround = false;
        }
    }
    void JumpingW()
    {
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            rb.AddForce(new Vector2(0, jumping_force), ForceMode2D.Impulse);
            isOnGround = false;
        }
    }
    void Update()
    {

        JumpingSpace();
        JumpingW();
        MovingSystem();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
}
    
