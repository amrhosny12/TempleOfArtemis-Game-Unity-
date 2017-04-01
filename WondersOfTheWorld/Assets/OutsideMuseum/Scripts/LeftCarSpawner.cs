using UnityEngine;
using System.Collections;

public class LeftCarSpawner : MonoBehaviour {

	public GameObject Car1;
	public GameObject Car2;
	public GameObject Car3;
	public GameObject Car4;
	public float xCar1Pos;
	public float yCar1Pos;

	float maxC1SpawnRateInSec = 0f;
	float maxC2SpawnRateInSec = 2.2f;
	float maxC3SpawnRateInSec = 4.5f;
	float maxC4SpawnRateInSec = 6.7f;

	// Use this for initialization
	void Start () {

		Invoke ("SpawnCar1", maxC1SpawnRateInSec);
		Invoke ("SpawnCar2", maxC2SpawnRateInSec);
		Invoke ("SpawnCar3", maxC3SpawnRateInSec);
		Invoke ("SpawnCar4", maxC4SpawnRateInSec);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void SpawnCar1() {

		GameObject aCar1 = (GameObject)Instantiate (Car1);
		aCar1.transform.position = new Vector2 (xCar1Pos, yCar1Pos);
		ScheduleNxtSpawnCar1 ();
	}


	void ScheduleNxtSpawnCar1 (){

		float SpawnInSecs;

			SpawnInSecs = 3f;

		Invoke("SpawnCar1", SpawnInSecs);
	}


	void SpawnCar2() {

		GameObject aCar2 = (GameObject)Instantiate (Car2);
		aCar2.transform.position = new Vector2 (xCar1Pos, yCar1Pos);
		ScheduleNxtSpawnCar2 ();
	}

	void ScheduleNxtSpawnCar2 (){

		float SpawnInSecs;

			SpawnInSecs = 3f;

		Invoke("SpawnCar2", SpawnInSecs);
	}
		

	void SpawnCar3() {

		GameObject aCar3 = (GameObject)Instantiate (Car3);
		aCar3.transform.position = new Vector2 (xCar1Pos, yCar1Pos);
		ScheduleNxtSpawnCar3 ();
	}

	void ScheduleNxtSpawnCar3 (){

		float SpawnInSecs;

		SpawnInSecs = 3f;

		Invoke("SpawnCar3", SpawnInSecs);
	}


	void SpawnCar4() {

		GameObject aCar4 = (GameObject)Instantiate (Car4);
		aCar4.transform.position = new Vector2 (xCar1Pos, yCar1Pos);
		ScheduleNxtSpawnCar4 ();
	}

	void ScheduleNxtSpawnCar4 (){

		float SpawnInSecs;

		SpawnInSecs = 3f;

		Invoke("SpawnCar4", SpawnInSecs);
	}


}
		