using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dam : MonoBehaviour
{
	Animator animator;
	[SerializeField]
	private float maxHealth = 100f;
	public float MaxHealth
	{
		get
		{
			return maxHealth;
		}
		set
		{
			maxHealth = value;
		}
	}

	private float health = 100f;

	public float Health
	{
		get
		{
			return health;
		}
		set
		{
			health = value;
			if (health <= 0)
			{
				IsDead = false;
			}
		}
	}

	[SerializeField]
	private bool _isDead = false;
	[SerializeField]
	private bool isInvincible;
	public float invicibilityTime = 0.5f;
	private float timeSinceHit = 0f;

	public bool IsDead
	{
		get
		{
			return _isDead;
		}
		private set
		{
			_isDead = value;
			//animator.SetBool(AnimationString.isDead, value);
		}
	}

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}
	private void Update()
	{
		if (isInvincible)
		{
			if (timeSinceHit > invicibilityTime)
			{
				isInvincible = false;
				timeSinceHit = 0;
			}
			timeSinceHit += Time.deltaTime;
		}
		Hit(5);
	}
	public void Hit(float damage)
	{
		if (!IsDead && !isInvincible)
		{
			Health -= damage;
			isInvincible = true;
		}
	}
}
