using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;		//Array of all the back and foreground to be parallaxed
	private float[] parallaxScales; 	//The proportions of the camera's movement to move the background by
	public float smoothing = 1f;		//How smooth the parallax is going to be. Must be aove 0

	private Transform cam;				//Teference to the main camera transform
	private Vector3 previousCamPos;		//The position of the camera in the previous frame

	//Called before start(). Great for references
	void Awake(){
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;

		//Assigning coresponding parallaxScales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales [i] = backgrounds [i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < backgrounds.Length; i++) {
			//The parallax is the opposite of the camera movement.
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			//Set the target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			//Create a target position which is the background's current position with it's target X postiion.
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
		
			//Fade between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		//Set the previousCamPos to the camera's position at the end of the frame
		previousCamPos = cam.position;
	}
}
