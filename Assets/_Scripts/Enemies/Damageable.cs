using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    Animator animator;
    Collider2D col;
    Rigidbody2D rb;
    InstantDeath id;
    ShieldScript shield;
    Healthbar healthbar;
    
    [SerializeField]
    public float _maxHealth = 100f;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		col = GetComponent<Collider2D>();
		rb = GetComponent<Rigidbody2D>();
		id = FindObjectOfType(typeof(InstantDeath)) as InstantDeath;
		shield = GetComponentInChildren<ShieldScript>();
		healthbar = FindObjectOfType<Healthbar>();
	}

	private void Start()
	{
		_health = _maxHealth;
		if (gameObject.tag == "Player")
			healthbar.SetMaxHealth(_health, _maxHealth);
	}


	public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

	[SerializeField]
	public float _health = 100f;
        
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if(_health <= 0)
            {
                IsAlive = false;
                col.enabled = false;
                rb.simulated = false;
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                if (gameObject.tag == "Player")
                {
                    id.DeathOnCall();                    
                }
			}
		}
    }

    [SerializeField]
    public bool _isAlive = true;
	[SerializeField]
	public bool isInvincible;

	public float invicibilityTime = 0.5f;
	private float timeSinceHit = 0f;

	public bool IsAlive { get
        {
            return _isAlive;
        }
        private set
        {
            _isAlive = value;
            animator.SetBool(AnimationString.isAlive, value);
        }
    }

	
	private void Update()
	{
		if(isInvincible)
        {
            if(timeSinceHit > invicibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
	}
	public void Hit(float damage)
    {
        if(IsAlive)
        {
			if (gameObject.tag == "Player")
            {
                if(!isInvincible && shield.isBlocking == false)
                {
					Health -= damage;
                    healthbar.SetHealth(_health);
                    isInvincible=true;
					animator.SetTrigger(AnimationString.hit);
				}
				else if (IsAlive && !isInvincible && shield.isBlocking == true)
				{
					animator.SetTrigger(AnimationString.blocked);
				}
			}
            if(gameObject.tag == "Enemy")
            {
				Health -= damage;
				animator.SetTrigger(AnimationString.hit);
			}			
        }        
    }
}
