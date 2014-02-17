using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed = 0.2f;
	public float new_y = 0f;
	public float old_y = 0f;
	public float current_y = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)){
			//Debug.Log (Time.time);
			//old_y = old_y + 0.1;
			new_y = new_y + 0.02f;
			renderer.material.mainTextureOffset = new Vector2(0f, new_y * speed);
			//old_y = new_y;
		}

		if (Input.GetKey(KeyCode.S)){
			//Debug.Log (Time.time);
			//old_y = old_y + 0.1;
			new_y = new_y - 0.02f;
			renderer.material.mainTextureOffset = new Vector2(0f, new_y * speed);
			//old_y = new_y;
		}
	}

	//	void OnGUI(){
	//		GUI.Box (Rect.MinMaxRect(Camera.main.transform.position.x,Camera.main.transform.position.y,100,100), Camera.main.fieldOfView.ToString());
	//	}
}
