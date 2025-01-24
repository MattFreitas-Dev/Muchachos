using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    Collider2D col;    
    Animator animator;
        
	private void Awake()
	{		
        animator = GetComponentInParent<Animator>();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {		
        if(animator.GetBool(AnimationString.blocking) == true)
        {
            
        }
	}	
}
