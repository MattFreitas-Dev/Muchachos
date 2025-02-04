using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBanditAttack : MonoBehaviour
{
    Collider2D atkcColl;
	public float attackDamage = 10;

	private void Awake()
	{
		atkcColl = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Damageable damageable = collision.GetComponent<Damageable>();

		if (damageable != null)
		{
			damageable.Hit(attackDamage);
		}
	}
}
