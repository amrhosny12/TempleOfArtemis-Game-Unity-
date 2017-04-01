using UnityEngine;
using System.Collections;

public class hurtPlayer : MonoBehaviour {

	public int damage; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.name == "Player") {
			healthManager.hurtPlayer (damage);
			other.GetComponent<AudioSource> ().Play ();
		

			var player = other.GetComponent<PlayerController> ();
			player.knockbackCount = player.knockbackTime;

			if (other.transform.position.x < transform.position.x)
				player.knockFromRight = true;
			else
				player.knockFromRight = false;
		}
	}
}
