using UnityEngine;
using System.Collections;

public class Car1Controls : MonoBehaviour {

	float speed;
	public float xPos;
	public float yPos;
	// Use this for initialization
	void Start () {

		speed = 50f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector2 position = transform.position;

		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);

		transform.position = position;

		if (transform.position.x > xPos) {
			Destroy (gameObject);
		}
}
}

