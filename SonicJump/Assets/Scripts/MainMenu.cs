using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI(){
		if (GUI.Button (new Rect (0, 0, 50, 25), "Menu")) 
		{
			GUI.Button (new Rect(100,100,300,300), "asdf");
			Debug.Log("Box should have been created");
		}
	}
}
