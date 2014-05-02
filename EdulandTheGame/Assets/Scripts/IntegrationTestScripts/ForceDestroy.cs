using UnityEngine;
using System.Collections;

public class ForceDestroy : MonoBehaviour {
	private bool youPass = false;
	private bool youPass2 = false;
	private bool youPass3 = false;
	private bool youPass4 = false;
	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		rigidbody2D.AddForce(new Vector2(GameObject.Find ("temp_character").GetComponent<PlayerMove> ().maxSpeed * 1000, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("temp_character").GetComponent<PlayerMove> ().interact && youPass == false && !GameObject.Find ("temp_character").GetComponent<PlayerMove> ().isCollision) {
			GameObject.Find ("temp_character").GetComponent<PlayerMove> ().stringToEdit = "cat";
			youPass = true;
		}
		else if (GameObject.Find ("temp_character").GetComponent<PlayerMove> ().interact && youPass == true && youPass2 == false && !GameObject.Find ("temp_character").GetComponent<PlayerMove> ().isCollision) {
			GameObject.Find ("temp_character").GetComponent<PlayerMove> ().stringToEdit = "bat";
			youPass2 = true;
		}
		else if (GameObject.Find ("temp_character").GetComponent<PlayerMove> ().interact && youPass == true && youPass2 == true && youPass3 == false && !GameObject.Find ("temp_character").GetComponent<PlayerMove> ().isCollision) {
			GameObject.Find ("temp_character").GetComponent<PlayerMove> ().stringToEdit = "turkey";
			youPass3 = true;
		}
		else if (GameObject.Find ("temp_character").GetComponent<PlayerMove> ().interact && (youPass == true || youPass2 == true || youPass3 == true) && GameObject.Find ("temp_character").GetComponent<PlayerMove> ().isCollision) {
			Destroy(GameObject.Find ("temp_character").GetComponent<PlayerMove> ().whatIHit.collider.gameObject);
			youPass4 = true;
		}
		else if(!GameObject.Find ("temp_character").GetComponent<PlayerMove> ().interact && youPass4 == true){
			IntegrationTest.Pass (gameObject);
		}
	}
}
