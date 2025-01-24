using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos, lenght;
    public GameObject cam;
    public float parallaxEffect;
    public bool parallaxTrue = true;

	// Start is called before the first frame update
	void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //calculate distance backgorund move based on cam move
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector2 (startPos + distance, transform.position.y);

        if (parallaxTrue)
        {
			ParallaxEffect(movement);
		}
        
    }

		public void ParallaxEffect(float movement)
    {
		// if vackgound has reached the end of its lenght adjust its position for infinite scrolling
		if (movement > startPos + lenght)
		{
			startPos += lenght;
		}
		else if (movement < startPos - lenght)
		{
			startPos -= lenght;
		}
	}
}
