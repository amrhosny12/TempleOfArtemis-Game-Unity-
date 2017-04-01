using UnityEngine;
using System.Collections;

public class Burn_Temple : MonoBehaviour {


	public bool TempleCheckCol;
	public GameObject temple;
	public GameObject templeStairs;
	public GameObject player;
	public GameObject boxedIn_1;
	public GameObject boxedIn_2;
	public GameObject DelayForChangeScene;
	public string GameOver;
	Animator anim;


	public int maxBricks;
	public GameObject bricks;
	public int horizontalMin;
	public int horizontalMax;
	public int verticalMin;
	public int verticalMax;


	int Spawn_Statues = 1;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		boxedIn_1.SetActive(false);
		boxedIn_2.SetActive(false);

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space) && TempleCheckCol) {

			boxedIn_1.SetActive (true);
			boxedIn_2.SetActive(true);
			anim.SetInteger ("State", 1);
			Destroy (temple, 6.0f);
			Destroy (player, 6.0f);
			Destroy (DelayForChangeScene, 12.0f);
			Destroy (templeStairs, 6.0f);
			//Destroy (gameObject, 10.0f);
		}
	 

		if (temple == null){
			
			if (Spawn_Statues == 1){
			   Spawn ();
			   Spawn_Statues++;
	}
	}

		if (DelayForChangeScene == null) {
			Initiate.Fade (GameOver, Color.black, 0.5f);
		}
}
	void Spawn()
	{
		for (int i = 0; i < maxBricks; i++) 
		{
			//Vector2 randomPosition = originalPosition + new Vector2 (Random.Range (horizontalMin, horizontalMax), Random.Range (verticalMin, verticalMax));
			Vector2 randomPosition = new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
			Instantiate (bricks, randomPosition, Quaternion.identity);
			//originalPosition = randomPosition;
		}

	}

	public void OnTriggerStay2D (Collider2D col){

		if (col.tag == "Player") {


			TempleCheckCol = true;
		}
	}
	public void OnTriggerExit2D (Collider2D col){

		TempleCheckCol = false;
}
}
