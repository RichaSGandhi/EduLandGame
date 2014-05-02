// JavaScript
var paused: boolean;

function OnGUI () {
	if (GUI.Button (Rect (0,0,80,20), "Pause")) {
		//Application.LoadLevel("PauseMenu");
		Time.timeScale =0;
		paused = true;
	}
	
	if(paused == true){	
		if (GUI.Button (Rect (Screen.width/2,Screen.height/2,80,20), "Resume")) {
			Time.timeScale = 1;
			paused = false;
		}
		
		if (GUI.Button (Rect (Screen.width/2,Screen.height/2 + 40,80,20), "Quit")) {
			Application.Quit();
		}
	}
	
	//Debug.Log(paused);
}