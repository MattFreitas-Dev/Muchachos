using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
	Slider slider;

	private void Awake()
	{
		slider = GetComponent<Slider>();
	}

	public void SetMaxHealth(float health, float maxHealth)
	{
		slider.maxValue = maxHealth;
		slider.value = health;
	}
	public void SetHealth(float health)
	{
		slider.value = health;
	}
}
