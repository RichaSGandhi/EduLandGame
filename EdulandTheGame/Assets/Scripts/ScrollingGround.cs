using UnityEngine;
using System.Collections;

public class ScrollGroundLogic {
	public float mySpeed;
	private Vector2 myVect;
	
	public Vector2 updateScrollGround (float spd){
		myVect = new Vector2 ((spd) % 1, 0f);
		return myVect;
	}
	public float checkSpeedGround (float spd)
	{
		mySpeed = spd + .001f;
		return mySpeed;
	}
}


public class ScrollingGround : MonoBehaviour {
	float speed = .001f;
	public GameObject temp_character;
	float timeVar;
	ScrollGroundLogic SGT = new ScrollGroundLogic();
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			if(GameObject.Find("temp_character").transform.position.x > 4 && PlayerMove.destroyedPrevious == true){
				timeVar = Time.time;
					renderer.material.mainTextureOffset = SGT.updateScrollGround(speed);;
					speed = SGT.checkSpeedGround(speed);
			}
		}
		
	}
}