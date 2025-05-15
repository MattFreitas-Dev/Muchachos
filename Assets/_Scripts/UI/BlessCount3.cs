using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BlessCount3 : MonoBehaviour
{
	public TextMeshProUGUI blessCountText;
	// Start is called before the first frame update
	void Start()
	{
		UpdateText();
	}
	public void UpdateText()
	{
		blessCountText.text = GameObject.Find("Player_1_v0.2").GetComponent<P1v2_Movement>().blessings.ToString();
	}
}
