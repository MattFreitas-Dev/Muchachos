using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Jump : MonoBehaviour
{
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    public float checkRadius;
    
    private Rigidbody2D rb;
    public float jumpForce = 8f;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            Debug.Log(isGrounded);
        }
        if(isGrounded == true)
        {
			animator.SetBool("IsJumping", false);
			animator.SetBool("IsFalling", false);
		}
        else if (isGrounded == false && rb.velocity.y > 0) 
        { 
            animator.SetBool("IsJumping", true); 
            animator.SetBool("IsFalling", false);
        }
        else if(isGrounded == false && rb.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
		}

    }
	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer); 
	}
}
