using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class ItaloBlock : MonoBehaviour
{
	// Event fired off when an attack is blocked. The parameter is the GameObject of the entity that was blocked
	//public event Action<GameObject> OnBlock;

	private bool isBlockWindowActive;
	private bool shouldUpdate;

	private float nextWindowTriggerTime;

	//My doings
	private List<GameObject> enemies = new List<GameObject>();
	float fScale = 1f;
	int scale = 1;
	Animator animator;
	Damageable damageable;

	private void Start()
	{		
		animator = GetComponent<Animator>();
		damageable = GetComponent<Damageable>();

		Enemies = Enemies ? Enemies : transform.gameObject;

		fScale = transform.localScale.x;
		scale = (int)Math.Round(fScale);
	}
	//end of my doings

	private void StartBlockWindow()
	{
		isBlockWindowActive = true;
		shouldUpdate = false;
	}
	private void StopBlockWindow()
	{
		isBlockWindowActive = false;
		shouldUpdate = false;
	}
	//mu doing
	[field: SerializeField] public GameObject Enemies { get; private set; }
	public void OnBlock2(InputAction.CallbackContext context)
	{
		if (context.started & Keyboard.current[Key.Z].wasPressedThisFrame)
		{
			animator.SetBool(AnimationString.blocking, true);
			damageable.isInvincible = true;
		}
		else if (Keyboard.current[Key.Z].wasReleasedThisFrame)
		{
			animator.SetBool(AnimationString.blocking, false);
			damageable.isInvincible = false;
		}
	}
	//end

	[field: SerializeField] public DirectionalInformation[] BlockDirectionInformation { get; private set; }

	private bool IsAttackBlocked(Transform source, out DirectionalInformation directionalInformation)
	{
		var angleOfAttacker = AngleFromFacingDirection(transform,source, scale);

		return IsBlocked(angleOfAttacker, out directionalInformation);
	}

	public static float AngleFromFacingDirection(Transform receiver, Transform source, int direction)
	{
		return Vector2.SignedAngle(Vector2.right * direction,
			source.position - receiver.position) * direction;
	}
	

	public bool IsBlocked(float angle, out DirectionalInformation directionalInformation)
	{
		directionalInformation = null;

		foreach (var directionInformation in BlockDirectionInformation)
		{
			var blocked = directionInformation.IsAngleBetween(angle);

			if (!blocked)
				continue;

			directionalInformation = directionInformation;
			return true;
		}

		return false;
	}
		

	private void Update()
	{
		if (!shouldUpdate || !IsPastTriggerTime())
			return;

		if (isBlockWindowActive)
		{
			StopBlockWindow();
		}
		else
		{
			StartBlockWindow();
		}

	}

	private bool IsPastTriggerTime()
	{
		return Time.time >= nextWindowTriggerTime;
	}
}
