using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTurnScript : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;

	public float speed = 10f;

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
		if (rb.velocity.x == 0)
        {
            gameObject.transform.position = gameObject.transform.position;
        }
        else if (rb.velocity.x > 0)
        {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x + 3, player.position.y + 2, player.position.z), step);
			//gameObject.transform.position = new Vector2(player.position.x + 3, player.position.y + 2);
        }
        else if (rb.velocity.x < 0)
        {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x - 3, player.position.y + 2, player.position.z), step);
			//gameObject.transform.position = new Vector2(player.position.x - 3, player.position.y + 2);
        }
        if(rb.velocity.y < 0 || rb.velocity.y > 0)
        {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y, player.position.z), step);
		}
	}
}
