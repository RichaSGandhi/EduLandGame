using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (GameObject.Find ("temp_character").transform.position.x, GameObject.Find ("temp_character").transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(GameObject.Find ("temp_character").transform.position.x, GameObject.Find ("temp_character").transform.position.y, transform.position.z);
	}
}
