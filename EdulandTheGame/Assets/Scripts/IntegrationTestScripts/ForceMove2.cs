using UnityEngine;
using System.Collections;

public class ForceMove2 : MonoBehaviour {
	private bool youPass = false;
	private bool youPass2 = false;
	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		rigidbody2D.AddForce(new Vector2(GameObject.Find ("temp_character").GetComponent<PlayerMove> ().maxSpeed * 1000, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("temp_character").GetComponent<PlayerMove> ().interact && youPass == false) {
			rigidbody2D.AddForce(new Vector2(GameObject.Find ("temp_character").GetComponent<PlayerMove> ().maxSpeed * -10000, 0));
			youPass = true;
		}
		else if (!GameObject.Find ("temp_character").GetComponent<PlayerMove> ().interact && youPass == true && youPass2 == false) {
			rigidbody2D.AddForce(new Vector2(GameObject.Find ("temp_character").GetComponent<PlayerMove> ().maxSpeed * 100000, 0));
			youPass2 = true;
		}
		else if (GameObject.Find ("temp_character").GetComponent<PlayerMove> ().interact && youPass == true && youPass2 == true) {
			IntegrationTest.Pass (gameObject);		
		}
	}
}
