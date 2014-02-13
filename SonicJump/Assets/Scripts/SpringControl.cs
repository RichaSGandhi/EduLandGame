using UnityEngine;
using System.Collections;

public class SpringControl : MonoBehaviour {

	public Sprite aSpring;

	// Use this for initialization
	void Start () {
		aSpring = new Sprite ();
	}
	
	// Update is called once per frame
	void Update () {
		Renderer.Instantiate (aSpring);
//		if (aSpring.hideFlags) {
//			aSpring.hideFlags = false;
//		} else {
//			aSpring.hideFlags = true;
//		}
	}
}
