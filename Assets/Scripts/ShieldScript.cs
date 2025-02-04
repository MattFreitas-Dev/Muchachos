using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldScript : MonoBehaviour
{
    Collider2D col;    
    Animator animator;
	Damageable damageable;
	Collider2D playerColl;
	Collider2D shieldColl;

	public bool isBlocking = false;
	public bool attackBlocked = false;
	public float attackReduction = 100f;


	private void Awake()
	{		
        animator = GetComponentInParent<Animator>();
		shieldColl = GetComponent<BoxCollider2D>();
	}
	// Start is called before the first frame update
	void Start()
    {
		damageable = GetComponent<Damageable>();
	}

    // Update is called once per frame
    void Update()
    {	

	}

	public void OnBlock2(InputAction.CallbackContext context)
	{
		if (context.started & Keyboard.current[Key.Z].wasPressedThisFrame)
		{
			animator.SetBool(AnimationString.blocking, true);

			isBlocking = true;
		}
		else if (Keyboard.current[Key.Z].wasReleasedThisFrame)
		{
			animator.SetBool(AnimationString.blocking, false);
			isBlocking = false;
		}
	}

	public void DetectAttack()
	{
		//GetVariable<attackDamage>
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Collider2D coll = collision.GetComponent <Collider2D>();

		if (coll != null)
		{
			Debug.Log("AttackDetected");
			attackBlocked = true;
			//change the Damageable script "Hit" to check for collision with the shield instead of isblcoking boolean
		}			
	}
}
