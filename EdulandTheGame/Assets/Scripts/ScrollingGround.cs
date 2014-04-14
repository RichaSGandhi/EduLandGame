using UnityEngine;
using System.Collections;

public class ScrollingGround : MonoBehaviour {
	float speed = .001f;
	public GameObject temp_character;
	float timeVar;
	// Use this for initialization
	void Start () {
		
	}
	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			if(GameObject.Find("temp_character").transform.position.x > 4 && PlayerMove.destroyedPrevious == true){
				timeVar = Time.time;
				renderer.material.mainTextureOffset = new Vector2 ((/*Time.time */ speed) % 1, 0f);
				speed = speed + .001f;
			}
		}
		
		
		/*public float speed = 0.2f;
		public float new_y = 0f;
		public float new_x = 0f;
		public float current_y = 0f;
		public float current_x = 0f;
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKey(KeyCode.D)){
				Debug.Log (current_x);
				
				new_x = new_x + 0.02f;
				current_x = new_x * speed;
				renderer.material.mainTextureOffset = new Vector2(current_x, current_y);
			}
			
			/*if (Input.GetKey(KeyCode.A)){
			Debug.Log (current_x);
			
			new_x = new_x - 0.02f;
			current_x = new_x * speed;
			renderer.material.mainTextureOffset = new Vector2(current_x, current_y);
		}
		
		if (Input.GetKey(KeyCode.W)){
			//Debug.Log (Time.time);
			//old_y = old_y + 0.1;
			new_y = new_y + 0.02f;
			current_y = new_y * speed;
			renderer.material.mainTextureOffset = new Vector2(current_x, current_y);
		}
		
		/*if (Input.GetKey(KeyCode.S)){
			//Debug.Log (Time.time);
			
			new_y = new_y - 0.02f;
			current_y = new_y * speed;
			renderer.material.mainTextureOffset = new Vector2(current_x, current_y);
		}*/
		
	}
}