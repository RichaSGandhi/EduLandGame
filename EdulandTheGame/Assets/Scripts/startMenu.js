// JavaScript
function OnGUI () {
	if (GUI.Button (Rect (Screen.width/2,Screen.height/2,80,20), "Start")) {
		Application.LoadLevel("Level1");
	}
	
	if (GUI.Button (Rect (Screen.width/2,Screen.height/2 + 40,80,20), "Quit")) {
		Application.Quit();
	}
}