using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTextureOffset = new Vector2 (0f,Time.time * speed);
	}

	//	void OnGUI(){
	//		GUI.Box (Rect.MinMaxRect(Camera.main.transform.position.x,Camera.main.transform.position.y,100,100), Camera.main.fieldOfView.ToString());
	//	}
}
