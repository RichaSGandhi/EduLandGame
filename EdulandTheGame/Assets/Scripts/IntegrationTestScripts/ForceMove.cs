using UnityEngine;
using System.Collections;

public class ForceMove : MonoBehaviour {
	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		rigidbody2D.AddForce(new Vector2(GameObject.Find ("temp_character").GetComponent<PlayerMove> ().maxSpeed * 1000, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("temp_character").GetComponent<PlayerMove> ().interact) {
			IntegrationTest.Pass (gameObject);		
		}
	}
}
