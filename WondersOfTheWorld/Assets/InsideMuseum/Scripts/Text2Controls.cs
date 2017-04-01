using UnityEngine;
using System.Collections;

public class Text2Controls : MonoBehaviour {

	public string SceneBack;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {

			Initiate.Fade (SceneBack, Color.black, 0.5f);
		}

	}
}
