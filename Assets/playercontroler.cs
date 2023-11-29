using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;
    public bool onGround;



    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("ground"))
            onGround = true;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("ground"))
            onGround = false;
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontal * movespeed, rb.velocity.y);
        if (horizontal > 0)

        transform.localScale = new Vector3(-1,1,1);
        else if (horizontal < 0 )
        transform.localScale = new Vector3(1, 1, 1);
        if (vertical > 0.1f || jump > 0.1f)
        {
            if(onGround) 
            movement.y = jumpforce;
        }
        rb.velocity = movement;
    }
}
