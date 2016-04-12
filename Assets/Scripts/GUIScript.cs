using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	void OnGUI () {
        Rect rect = new Rect(0, 0, Screen.width / 2, Screen.height / 2);
        rect.center = new Vector2(Screen.width/2, Screen.height/2);
		// Make a background box
		GUI.Box(rect, "Menu Box");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(10, 10, 100, 90), "Level 1")) {
			
		}
	}
}
