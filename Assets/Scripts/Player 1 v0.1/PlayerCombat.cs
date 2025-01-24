using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public int attackDamage = 5;
    public float attackRate = 2f;


    // Update is called once per frame
    void Update()
    {   
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Attack();
			}
        
    }

    void Attack()
    {

        //detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

		//damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
	}

	private void OnDrawGizmosSelected()
	{
        if ((attackPoint == null))
        {
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
	}
}
