using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BlessingCountScript : MonoBehaviour
{
	P1v2_Movement playerScript;
	public Text blessCountText;
	[SerializeField]
	int localBless = 0;
	// Start is called before the first frame update
	void Start()
    {
		playerScript = GameObject.Find("Player_1_v0.2").GetComponent<P1v2_Movement>();
		localBless = playerScript.blessings;
		UpdateText();		
	}
	private void FixedUpdate()
	{
		Debug.Log(playerScript.blessings);
	}
	public void UpdateText()
	{
		//localBless = playerScript.blessings;
		//blessCountText.text = "test";
		blessCountText.text = GameObject.Find("Player_1_v0.2").GetComponent<P1v2_Movement>().blessings.ToString();
	}
}
