using UnityEngine;
using System.Collections;

public class moveNPC : MonoBehaviour {

	bool facingRight= true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > -24) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		else if (transform.position.x < -48) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		if (!facingRight) {
			transform.Translate (new Vector3 (-0.01f, 0));
		} else {
			transform.Translate (new Vector3 (0.01f, 0));
		}
	}
}
