using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

	private float horizontal;
	private float speed = 8f;
    //private float jumpingPower = 8f;
    private bool isFacingRight = true;

    //private bool grounded;
    //private bool isFalling = false;

    [SerializeField] private Rigidbody2D rb;
    /*[SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;*/
    [SerializeField] private Animator animator;


    // Update is called once per frame
    void Update()
    {
        Flip();

        horizontal = Input.GetAxis("Horizontal");
		animator.SetFloat("Speed", Mathf.Abs(horizontal));

		/*if (Input.GetButtonDown("Jump") && IsGrounded())
        {
			Debug.Log("is Jumping");
			rb.velocity = new Vector2 (rb.velocity.x, jumpingPower);
        }
        
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }*/
    }

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
	}

	/*private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
	}*/


	private void Flip()
    {
        if(isFacingRight == false && horizontal > 0f || isFacingRight == true && horizontal < 0f)
        {
           isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
