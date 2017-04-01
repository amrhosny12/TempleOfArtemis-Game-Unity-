using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	[SerializeField]
	private float xMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float yMin;



	public Transform target;
	public float yOffSet;

	// Use this for initialization
	void Start () {
	
	}
	
	void LateUpdate () {
		
		transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax), 
			Mathf.Clamp (target.position.y, yMin, yMax) + yOffSet, 
			transform.position.z);

	
	}
}
