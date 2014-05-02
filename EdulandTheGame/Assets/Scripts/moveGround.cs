using UnityEngine;
using System.Collections;

public class moveGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -5.5 && (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W))) {
			transform.Translate(new Vector3(0,0.01f));
		}
		else if (transform.position.y >= -8 && (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S))) {
			transform.Translate(new Vector3(0,-0.01f));
		}
	}
}
