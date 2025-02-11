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
	P1v2_Movement playerScript;
	int blessingsCount = 3;
	// Start is called before the first frame update
	void Start()
    {
        
		animator = GetComponent<Animator>();
		animator.enabled = false;		
		retry = GameObject.Find("Retry");		
		blessingsCount = playerScript.blessings;
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
		if (blessingsCount > 0)
		{
			retry.GetComponent<Canvas>().enabled = true;
			retry.GetComponent<Animator>().enabled = true;
			blessingsCount--;
			playerScript.blessings = blessingsCount;
			BlessingCountScript.UpdateText();
		}
		else
			SceneManager.LoadScene(3);

	}
}
