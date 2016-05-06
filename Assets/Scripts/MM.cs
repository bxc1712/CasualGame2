using UnityEngine;
using System.Collections;

public class MM : MonoBehaviour {
    private bool paused;
    private bool showGUI;


    void Start()
    {
        paused = false;
        showGUI = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            paused = !paused;
            showGUI = !showGUI;
        }

        if(paused == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void startGame(string changeTo)
	{
		Application.LoadLevel(changeTo);
	}

    public void loadInstructions()
    {

    }

}
