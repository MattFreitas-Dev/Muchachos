using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldScript : MonoBehaviour
{
	Animator animator;

	public bool isBlocking = false;
	public bool attackBlocked = false;


	private void Awake()
	{
		animator = GetComponentInParent<Animator>();
	}

	public void OnBlock2(InputAction.CallbackContext context)
	{
		if (context.started & Keyboard.current[Key.Z].isPressed)
		{
			animator.SetBool(AnimationString.blocking, true);
		}
		else if (Keyboard.current[Key.Z].wasReleasedThisFrame)
		{
			animator.SetBool(AnimationString.blocking, false);
			attackBlocked = false;
			isBlocking = false;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Collider2D coll = collision.GetComponent<Collider2D>();

		if (coll != null)
		{
			attackBlocked = true;
			isBlocking = true;
		}
	}
}
