﻿//C#
using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {
	void OnGUI () {
		// Make a background box
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 - 40, 100, 90), "Developers:");
		GUI.Label(new Rect(Screen.width/2, Screen.height/2 - 40, 100, 90), "Patrick Walsh");
		GUI.Label(new Rect(Screen.width/2, Screen.height/2 - 20, 100, 90), "Shivani Mete");
		GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 90), "Corey Mattes");
		GUI.Label(new Rect(Screen.width/2, Screen.height/2 + 20, 100, 90), "Richa Gandhi");
		GUI.Label(new Rect(Screen.width/2, Screen.height/2 + 40, 100, 90), "Maarij Anwar");

		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2 +60,80,20), "Back")) {
			Application.LoadLevel("StartMenu");
		}
	}
}