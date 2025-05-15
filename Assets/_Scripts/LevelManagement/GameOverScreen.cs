using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class GameOverScreen : MonoBehaviour
{
    GameObject player;
	GameObject retry;
    Damageable invincible;
    Healthbar healthbar;
	P1v2_Movement playerScript;
    BlessCount2 blessCount2;
    BlessCount3 blessCount3;
	// Start is called before the first frame update
	void Start()
    {
        player = GameObject.Find("Player_1_v0.2");
		retry = GameObject.Find("Retry");
        invincible = GameObject.Find("Player_1_v0.2").GetComponent<Damageable>();
        playerScript = GameObject.Find("Player_1_v0.2").GetComponent<P1v2_Movement>();
		healthbar = FindObjectOfType<Healthbar>();
        blessCount2 = FindObjectOfType<BlessCount2>();
        blessCount3 = FindObjectOfType<BlessCount3>();
	}

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
    public void MyDebug()
    {
        Debug.Log("debug");
    }
    public void SaintsBlessing()
	{
        Debug.Log("Saints blessing");
        player.GetComponent<Animator>().ResetTrigger(AnimationString.hit);
		player.GetComponent<Animator>().SetTrigger(AnimationString.saint);
		SoundEffectManager.Play("Revive");

		player.GetComponent<Damageable>()._isAlive = true;
		player.GetComponent<Damageable>()._health = player.GetComponent<Damageable>()._maxHealth;

        healthbar.SetHealth(player.GetComponent<Damageable>()._health); //UI
        playerScript.blessings = playerScript.blessings -1;
		
		player.GetComponent<Animator>().SetBool(AnimationString.isAlive, true);
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<Rigidbody2D>().simulated = true;
		retry.GetComponent<Canvas>().enabled = false;
        retry.GetComponentInChildren<UnityEngine.UI.Button>().enabled = false;
		retry.GetComponent<Animator>().enabled = false;        

        blessCount2.UpdateText();
		blessCount3.UpdateText();

		invincible.isInvincible = true;
		/*reference player|
         * retry animation|
         * 
         * reference damageable script|
		_health = _maxHealth;|
		IsAlive = false;|
		col.enabled = false;
		rb.simulated = false;
        turn off saint screen*/
	}
}
