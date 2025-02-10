using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Block : MonoBehaviour
{
	Animator animator;
	public LayerMask layerMask;

	private void Start()
	{
		animator = GetComponent<Animator>();
		//touchingCol = GetComponent<CapsuleCollider2D>();
	}
	public void OnBlock(InputAction.CallbackContext context)
	{
		if (context.started & Keyboard.current[Key.Z].isPressed)
		{
			animator.SetBool(AnimationString.blocking, true);
			Debug.Log("Isblocking");
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, layerMask);
			Debug.DrawRay(transform.position, Vector2.right, Color.red, 1000f);
			if (hit)
			{
				Debug.Log("hit.rigidbody.name");
				
			}

			//var angleOfAttacker = AngleFromFacingDirection(myTransform, )
		}
		else if (Keyboard.current[Key.Z].wasReleasedThisFrame)
		{
			animator.SetBool(AnimationString.blocking, false);
			Debug.Log("Is not blocking");
		}
	}

	//[Range(-180f, 180f)] public float MinAngle;
	//[Range(-180f, 180f)] public float MaxAngle;
	//public bool IsAngleBetween(float angle)
	//{
	//	if (MaxAngle > MinAngle)
	//	{
	//		return angle >= MinAngle && angle <= MaxAngle;
	//	}

	//	return (angle >= MinAngle && angle <= 180f) || (angle <= MaxAngle && angle >= -180f);
	//}
	//public static float AngleFromFacingDirection(Transform receiver, Transform source, int direction)
	//{
	//	return Vector2.SignedAngle(Vector2.right * direction,
	//		source.position - receiver.position) * direction;
	//}
	//CapsuleCollider2D touchingCol;
	//RaycastHit2D[] enemyHits = new RaycastHit2D[5];
	//public ContactFilter2D castFilter;
	//public float enemyDistance = 5f;
	//private Vector2 enemyCheckDirection => gameObject.myTransform.localScale.x > 0 ? Vector2.right : Vector2.left;
	//[SerializeField] private bool _hasEnemy;
	//public bool HasEnemy
	//{
	//	get
	//	{
	//		return _hasEnemy;
	//	}
	//	private set
	//	{
	//		_hasEnemy = value;
	//	}
	//}

	private void FixedUpdate()
	{
		//HasEnemy = touchingCol.Cast(enemyCheckDirection, castFilter, enemyHits, enemyDistance) > 0;
	}
}
