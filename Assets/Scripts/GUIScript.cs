using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {

    //time vars
    public Text timerText;
    private float time;
    private float seconds;
    private float minutes;

    //score
    public Text scoreText;
    int score;

    //reference to controller for score
    private PlayerController controller;

    void Start()
    {
        //declaring
        controller = GameObject.Find("Snowball").GetComponent<PlayerController>();
    }

    void Update()
    {
        //set up numbers for time
        time += Time.deltaTime;
        seconds = Mathf.Floor(time % 60);
        minutes = Mathf.Floor(time / 60);

        //display timer
        timerText.text = minutes + ":" + seconds;
        //get position for timer
        timerText.transform.position = new Vector3(System.Convert.ToSingle(Screen.width * .1), System.Convert.ToSingle(Screen.height * .9), 0);

        //display score
        score = controller.score;
        scoreText.text = score.ToString();
        scoreText.transform.position = new Vector3(System.Convert.ToSingle(Screen.width * .9), System.Convert.ToSingle(Screen.height * .9), 0);
    }
}
