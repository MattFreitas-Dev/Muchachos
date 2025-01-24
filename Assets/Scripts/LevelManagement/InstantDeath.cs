using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantDeath : MonoBehaviour
{
    public int waitTime = 1;
	Animator animator;
	GameObject retry;
    // Start is called before the first frame update
    void Start()
    {
        
		animator = GetComponent<Animator>();
		animator.enabled = false;		
		retry = GameObject.Find("Retry");
	}

	// Update is called once per frame
	void Update()
    {
        
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
		retry.GetComponent<Canvas>().enabled = true;
		retry.GetComponent<Animator>().enabled = true;
	}
}
