using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ItaloBlock : MonoBehaviour
{
	// Event fired off when an attack is blocked. The parameter is the GameObject of the entity that was blocked
	public event Action<GameObject> OnBlock;

	private bool isBlockWindowActive;
	private bool shouldUpdate;

	private float nextWindowTriggerTime;

	//My doings
	private List<GameObject> enemies = new List<GameObject>();

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

	/*private bool IsAttackBlocked(Transform source, out DirectionalInformation directionalInformation)
	{
		var angleOfAttacker = AngleFromFacingDirection(Core.Root.transform,source,movement.FacingDirection);

		return currentAttackData.IsBlocked(angleOfAttacker, out directionalInformation);
	}*/

	public static float AngleFromFacingDirection(Transform receiver, Transform source, int direction)
	{
		return Vector2.SignedAngle(Vector2.right * direction,
			source.position - receiver.position) * direction;
	}
	private void Start()
	{
		Enemies = Enemies ? Enemies : transform.gameObject;
	}

	public GameObject Enemies { get; private set; }
}
