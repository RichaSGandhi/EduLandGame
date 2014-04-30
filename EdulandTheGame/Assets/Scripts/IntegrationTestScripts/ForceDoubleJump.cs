using UnityEngine;
using System.Collections;

public class ForceDoubleJump : MonoBehaviour {

	private float dist;
	private bool youPass = false;
	private float startTime;
	// Use this for initialization
	void Start () {
		dist = GameObject.Find ("temp_character").transform.position.y - GameObject.Find ("ground").transform.position.y;
		startTime = Time.time;
		rigidbody2D.AddForce(new Vector2(0, GameObject.Find ("temp_character").GetComponent<PlayerMove> ().jumpForce));
		rigidbody2D.AddForce(new Vector2(0, (GameObject.Find ("temp_character").GetComponent<PlayerMove> ().jumpForce)/2));
	}

	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("temp_character").transform.position.y - GameObject.Find ("ground").transform.position.y > dist + 3.6) {
			IntegrationTest.Fail (gameObject);	
		}
		else if (GameObject.Find ("temp_character").transform.position.y - GameObject.Find ("ground").transform.position.y > dist + 3.5) {
			youPass = true;		
		}
	}

	void FixedUpdate(){
		if (((startTime + 2) <= Time.time)  && youPass == true) {
			IntegrationTest.Pass (gameObject);
		}
	}
}
