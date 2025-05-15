using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Manager : MonoBehaviour
{
    public static Combat_Manager instance;

    public bool canReceiveInput;
    public bool inputReceived;

	private void Awake()
	{
		instance = this;
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            inputReceived = true;
            canReceiveInput = false;
        }
        else
        {
            return;
        }

	}
    public void InputManager()
    {
        if (!canReceiveInput)
        {
            canReceiveInput = true;
        }
        else 
        { 
            canReceiveInput = false;
        }
    }
}
