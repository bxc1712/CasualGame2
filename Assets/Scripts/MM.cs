using UnityEngine;
using System.Collections;

public class MM : MonoBehaviour {
    private bool paused;
    private bool showGUI;

    string levelName;

    void Start()
    {
        paused = false;
        showGUI = false;
        levelName = Application.loadedLevelName;
    }

    void Update()
    {
        if (Input.GetKeyDown("p") && levelName == "TestScene")
        {
            pauseGame();
        }   
    }

    public void startGame(string changeTo)
	{
		Application.LoadLevel(changeTo);
	}

    public void loadInstructions()
    {

    }

    void pauseGame()
    {
        paused = !paused;
        showGUI = !showGUI;
        Debug.Log("paused");
        if (paused == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}
