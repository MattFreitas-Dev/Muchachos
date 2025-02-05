using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTurnScript : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;

	public float speed = 10f;
	public float xDamping = 3f;
	public float yDamping = 2f;

	// Start is called before the first frame update
	void Start()
    {
		gameObject.transform.position = new Vector2(player.position.x + 3, player.position.y + 2);
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		float step = speed * Time.deltaTime;
		//Mathf.Lerp(transform.position.x, player.transform.position.x + 3, 0.5f);
		if (player.localScale.x == 0)
        {
			transform.position = transform.position;
		}
        else if (player.localScale.x > 0)
        {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x + xDamping, player.position.y + yDamping, player.position.z), step);
			//gameObject.transform.position = new Vector2(player.position.x + 3, player.position.y + 2);
        }
        else if (player.localScale.x < 0)
        {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x - xDamping, player.position.y + yDamping, player.position.z), step);
			//gameObject.transform.position = new Vector2(player.position.x - 3, player.position.y + 2);
        }
  //      if(rb.velocity.y < 0 || rb.velocity.y > 0)
  //      {
		//	transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y, player.position.z), step);
		//}
	}
}
