using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BlessingCountScript : MonoBehaviour
{
    P1v2_Movement playerScript;
    private int blessingsCount = 3;
	public Text blessCountText;
	// Start is called before the first frame update
	void Start()
    {
        playerScript = GetComponent<P1v2_Movement>();
        blessingsCount = playerScript.blessings;
    }
	private void FixedUpdate()
	{
		UpdateText();
		Debug.Log(blessCountText.text);
	}
	public void UpdateText()
	{
		blessCountText.text = blessingsCount.ToString();
	}
}
