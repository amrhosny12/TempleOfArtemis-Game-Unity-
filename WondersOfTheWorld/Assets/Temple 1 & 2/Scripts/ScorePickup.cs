using UnityEngine;
using System.Collections;

public class ScorePickup : MonoBehaviour {

	public int pointsToAdd = 20;

	void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<PlayerController>() == null)
			return;

			Score.AddPoints(pointsToAdd);

			Destroy (gameObject);
	}
}
