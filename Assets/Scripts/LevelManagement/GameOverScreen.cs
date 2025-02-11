using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GameOverScreen : MonoBehaviour
{
    GameObject player;
	GameObject retry;
    Damageable invincible;
    Healthbar healthbar;
    float playerHealth;
	// Start is called before the first frame update
	void Start()
    {
        player = GameObject.Find("Player_1_v0.2");
		retry = GameObject.Find("Retry");
        invincible = GameObject.Find("Player_1_v0.2").GetComponent<Damageable>();
        healthbar = FindObjectOfType<Healthbar>();
        playerHealth = player.GetComponent<Damageable>()._health;
	}

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void SaintsBlessing()
	{
        
        player.GetComponent<Animator>().ResetTrigger(AnimationString.hit);
		player.GetComponent<Animator>().SetTrigger(AnimationString.saint);        

        player.GetComponent<Damageable>()._isAlive = true;
		player.GetComponent<Damageable>()._health = player.GetComponent<Damageable>()._maxHealth;

		healthbar.SetHealth(playerHealth); //UI

		player.GetComponent<Animator>().SetBool(AnimationString.isAlive, true);
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<Rigidbody2D>().simulated = true;
		retry.GetComponent<Canvas>().enabled = false;
		retry.GetComponent<Animator>().enabled = false;

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
