using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class P1v2_Movement : MonoBehaviour
{
    //começo das variaveis
    //movement
    public float walksSpeed = 5f;
    public float airWalkSpeed = 3f;
	public bool _isFacingRight = true;
	public float jumpImpulse = 6f;
    public float comboTimer = 5f;
    public float cdTimer = 3f;
	public int blessings = 3;
    public float footStepSpeed = 0.5f;

	[SerializeField]
    private float comboTimerValue, cdTimerValue;
    private int cc = 0;
    private bool playinFootsteps = false;

	private Vector2 moveInput;
	Rigidbody2D rb;
    TouchingDirections touchingDirections;

	//animations
	private bool _isMoving = false;
    Animator animator;

    public float CurrentMoveSpeed 
    { 
        get
        {
            if (CanMove)
            {
				if (IsMoving && !touchingDirections.IsOnWall)
				{
					if (touchingDirections.IsGrounded)
					{
						return walksSpeed;
					}
					else
					{
						return airWalkSpeed;
					}

				}
				else
				{
					return 0;
				}
            }
            else { return 0; }
        } 
        private set
        {

        }
    }
	public bool isFacingRight { get { return _isFacingRight; } private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        } 
    }

	//primeira versão sem animação
	//public bool IsMoving { get; private set; }

	//segunda versão com animação
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
			StartFootstep(value);
		}
    }

    public bool CanMove {  
        get
        {
            return animator.GetBool(AnimationString.canMove);
        } 
    }

//fim das variaveis

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();

		//animation
		animator = GetComponent<Animator>();
	}
	// Start is called before the first frame update
	void Start()
    {
        cdTimerValue = 0f;
        comboTimerValue = 0f;
	}

    // Update is called once per frame
    void Update()
    {
		animator.SetInteger(AnimationString.comboCounter, cc);
		if (comboTimerValue <= 0)
		{
			cc = 0;
		}
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);

        animator.SetFloat(AnimationString.yVelocity, rb.velocity.y);

        cdTimerValue -= Time.deltaTime;
        comboTimerValue -= Time.deltaTime;
		animator.SetFloat(AnimationString.comboTimer, comboTimerValue);		
	}

	public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
        }else if(moveInput.x < 0 && isFacingRight)
        {
            isFacingRight=false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationString.jump);
			StartFootstep(false);
			rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started & cdTimerValue <= 0f)
        {
            animator.SetTrigger(AnimationString.attack);
			SoundEffectManager.Play("PlayerAttack", true);
			cdTimerValue = cdTimer;
            comboTimerValue = comboTimer;
            cc++;
			if (cc > 3)
			{
				cc = 1;
			}			
		}        
	}
    
 //   public void OnBlock(InputAction.CallbackContext context)
 //   {
	//	if (context.started & Keyboard.current[Key.Z].wasPressedThisFrame)
 //       {
 //           animator.SetBool(AnimationString.blocking, true);
 //       }
 //       else if (Keyboard.current[Key.Z].wasReleasedThisFrame)
 //       {
	//		animator.SetBool(AnimationString.blocking, false);
	//	}
	//}
    /*public bool IsPressed()
    {

    }*/
    public void OnTest(InputAction.CallbackContext context)
    {
        Debug.Log("Test");
	}

    public float AnimatorSpeed(float speed)
    {
        animator.speed = speed;
        return animator.speed;
    }

    void StartFootstep(bool value)
    {
        playinFootsteps = value;
        if(playinFootsteps == true)
        {
            InvokeRepeating(nameof(PlayFootStep), 0f, footStepSpeed);
        }
        else if(playinFootsteps == false)
        {
            CancelInvoke(nameof(PlayFootStep));
        }
    }
    void PlayFootStep()
    {
		SoundEffectManager.Play("Walk", true);
	}
}
