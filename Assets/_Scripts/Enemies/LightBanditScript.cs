using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TouchingDirections))]
public class LightBanditScript : MonoBehaviour
{
	Rigidbody2D rb;
	Animator animator;
	TouchingDirections touchingDirections;
	public DetectionZone attackZone;
	public DetectionZone cliffDetection;

	private bool _isMoving = false;
	public float walkSpeed = 5f;
	public float walkStopRate = 0.5f;
	
	public enum WalkableDirection { Right, Left};
	
	private WalkableDirection _walkDirection;
	
	private Vector2 walkDirectionVector = Vector2.right;
	
	public WalkableDirection WalkDirection
	{
		get { return _walkDirection;}
		set {
			if(_walkDirection != value)
			{
				gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

				if(value == WalkableDirection.Right )
				{
					walkDirectionVector = Vector2.right;
				}else if(value == WalkableDirection.Left)
				{
					walkDirectionVector = Vector2.left;
				}
			}
			
			_walkDirection = value; }
	}

	public bool _hasTarget = false;

	public bool HasTarget { 
		get
		{
			return _hasTarget;
		} 
		private set
		{
			_hasTarget = value;
			/*rb.velocity = new Vector2(0, 0);
			IsMoving = false;*/
			animator.SetBool(AnimationString.hasTarget, value);
			animator.SetBool(AnimationString.canMove, !value);
		}
	}

	// inicio scrip italo
	public bool IsMoving
	{
		get
		{
			return _isMoving;
		}
		private set
		{
			_isMoving = value;
			animator.SetBool(AnimationString.isMoving, value);
		}
	}
	//final scrip italo

	public bool CanMove
	{
		get
		{
			return animator.GetBool(AnimationString.canMove);
		}
	}

	public float AttackCD { get
		{
			return animator.GetFloat(AnimationString.attackCD);
		}
		private set
		{
			animator.SetFloat(AnimationString.attackCD, Mathf.Max(value, 0));
		}
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		touchingDirections = GetComponent<TouchingDirections>();
	}
	private void Start()
	{
		walkDirectionVector = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y);
	}

	private void FlipDirection()
	{
		if (WalkDirection == WalkableDirection.Right)
		{
			WalkDirection = WalkableDirection.Left;
		}
		else if (WalkDirection == WalkableDirection.Left)
		{
			WalkDirection = WalkableDirection.Right;
		}
		else
		{
			Debug.Log("Error");
		}
	}

	// Update is called once per frame
	void Update()
	{
		HasTarget = attackZone.detectedColliders.Count > 0;

		if(AttackCD > 0)
		{
			AttackCD-=Time.deltaTime;
		}
	}

	private void FixedUpdate()
	{
		if (touchingDirections.IsGrounded && (touchingDirections.IsOnWall || cliffDetection.detectedColliders.Count == 0))
		{
			FlipDirection();
		}

		if (CanMove)
		{
			rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
			IsMoving = true;
		}
		else
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
			IsMoving = false;
			//rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkStopRate), rb.velocity.y);
		}
	}	
}
