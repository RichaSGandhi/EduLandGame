using UnityEngine;
using System.Collections;

public class ScrollLogic {
	public float mySpeed;
	private Vector2 myVect;

	public Vector2 updateScroll (float spd){
		myVect = new Vector2 ((spd) % 1, 0f);
		return myVect;
		}
	public float checkSpeed (float spd,float spd2)
	{
		mySpeed = spd + spd2;
		return mySpeed;
	}
}


public class Scrolling : MonoBehaviour {
	public float speed = .0001f;
	float speed2;
	float timeVar;
	ScrollLogic ST = new ScrollLogic();

	// Use this for initialization
	void Start () {
		speed2 = speed;
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			if(GameObject.Find("temp_character").transform.position.x > 4 && PlayerMove.destroyedPrevious == true){
				timeVar = Time.time;
				renderer.material.mainTextureOffset = ST.updateScroll(speed);
				speed = ST.checkSpeed(speed,speed2);
			}
		}
		
	}
}