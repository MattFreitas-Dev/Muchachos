using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstantDeath : MonoBehaviour
{
    public int waitTime = 1;
	Animator animator;
	GameObject retry;
	BlessingCountScript BlessingCountScript;
	P1v2_Movement playerBless;
	// Start is called before the first frame update
	void Start()
    {
        
		animator = GetComponent<Animator>();
		animator.enabled = false;		
		retry = GameObject.Find("Retry");
		playerBless = GameObject.Find("Player_1_v0.2").GetComponent<P1v2_Movement>();
	}	

	public void OnTriggerEnter2D(Collider2D collision)
	{
		StartCoroutine(Death());
	}
	

	public IEnumerator Death()
	{
		animator.enabled = true;

		yield return new WaitForSeconds(waitTime);

		SceneManager.LoadScene(3);
	}
	
	public void DeathOnCall()
	{
		//call blessing screen
		Invoke("DeathWait", 1.0f);
	}

	public void DeathWait()
	{
		if (playerBless.blessings > 0)
		{
			retry.GetComponent<Canvas>().enabled = true;
			retry.GetComponent<Animator>().enabled = true;
		}
		else
			SceneManager.LoadScene(3);

	}
}
