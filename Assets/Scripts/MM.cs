using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class MM : MonoBehaviour {
    private bool paused;
    private bool showGUI;

    string levelName;

    void Start()
    {
        paused = false;
        showGUI = false;
        //levelName = SceneManager.GetActiveScene().name;
<<<<<<< HEAD
		levelName = Application.loadedLevelName;
=======
>>>>>>> 6a37c40fdd80ffdfd40dd65f9a29b7c481303221
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
		//SceneManager.LoadScene(changeTo);
<<<<<<< HEAD
		Application.LoadLevel(changeTo);
=======
>>>>>>> 6a37c40fdd80ffdfd40dd65f9a29b7c481303221
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
