using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class MM : MonoBehaviour {
    private bool paused;
    private bool showGUI;

    string levelName;

    private GameObject pMenu;
    void Start()
    {
        paused = false;
        showGUI = false;
        //levelName = SceneManager.GetActiveScene().name;
		levelName = Application.loadedLevelName;
        try
        {
            pMenu = GameObject.Find("PauseMenu");
        }

        catch
        {
            showGUI = false;
        }    
    }

    void Update()
    {
        //checks for paused game
        if (Input.GetKeyDown("p") && levelName == "TestScene")
        {
            pauseGame();
        }

        //shows paused game menu 
        if (showGUI)
        {
            pMenu.SetActive(true);
        }
        else
        {
            pMenu.SetActive(false);
        }
    }

    public void changeLevel(string changeTo)
	{
		//SceneManager.LoadScene(changeTo);
		Application.LoadLevel(changeTo);
	}

    public void pauseGame()
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
