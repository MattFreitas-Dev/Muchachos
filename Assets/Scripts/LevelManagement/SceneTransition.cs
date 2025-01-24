using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    Collider2D col;
    Animator animator;
	public float waitTime = 1f;
    public int sceneIndex;

	// Start is called before the first frame update
	void Start()
    {
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        //SceneManager.LoadScene(sceneName: "Scene3");
        StartCoroutine(Transition(sceneIndex));
	}

    IEnumerator Transition(int levelIndex)
    {
        animator.SetTrigger(AnimationString.startFade);

        yield return new WaitForSeconds(waitTime);

		SceneManager.LoadScene(levelIndex);
	}
}
