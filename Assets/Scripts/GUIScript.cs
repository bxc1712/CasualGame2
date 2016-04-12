using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

    private GUISkin startBtn;

    void Start()
    {
        //assigning skin
        startBtn = Resources.Load("ButtonSkin") as GUISkin;
    }

	void OnGUI () {

        GUI.skin = startBtn;
        //declaring rects for buttons
        Rect menuRect = new Rect(0, 0, Screen.width / 2, Screen.height / 2);
        Rect startRect = new Rect(0, 0, 200, 100);

        //centering buttons
        menuRect.center = new Vector2(Screen.width/2, Screen.height/2);
        startRect.center = new Vector2(Screen.width / 2, Screen.height/3);

        // Make a background box
        GUI.Box(menuRect, "Menu Box");
		
		// Make the start button
		if(GUI.Button(startRect, "Level 1")) {
			
		}
	}
}
