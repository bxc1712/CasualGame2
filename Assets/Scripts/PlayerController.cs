using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //changed from public to blank
    public float speed;
    //how fast the ball melts and the time interval
    public float meltSpeed;
    private float time;
    private float meltedTime;
    //reference to the gui time keeping
    private GUIScript clock;

    private float spWeight;
	private float chWeight;
	private float slowMulti;
	private Rigidbody rb; //changed from private to public

	Vector3 cameraDir;
	//Vars for Normalized MainCam Vectors
	Vector3 normForward;
	Vector3 normBack;
	Vector3 normLeft;
	Vector3 normRight;

    public int score;

    bool isAlive;
    
    void Start()
	{
        //melting vars
        clock = GameObject.Find("Canvas").GetComponent<GUIScript>();
        meltSpeed = 1f;
        meltedTime = 0;

        //commented out to try and chagne rb to public
		rb = GetComponent<Rigidbody>();
		spWeight=0.99f;
		chWeight=0.95f;

        score = 0;

        isAlive = true;

        speed = 15;
	}
	void FixedUpdate()
    {
		cameraDir = new Vector3(rb.transform.position.x,0,rb.transform.position.z) - new Vector3(Camera.main.transform.position.x,0,Camera.main.transform.position.z);
		cameraDir.Normalize();
		Vector3 movement = new Vector3 (cameraDir.x, 0.0f, cameraDir.y);
		//Debug.Log (cameraDir);
		//Debug.DrawRay(rb.position,Camera.main.transform.position,Color.red);
		//Debug.DrawRay(rb.position,rb.,Color.green);
//		float moveHorizontal=Input.GetAxis("Horizontal");
//		float moveVertical=Input.GetAxis("Vertical");

		//New Movement Code
		normForward=Camera.main.transform.forward;
		normBack=-Camera.main.transform.forward;
		normLeft=-Camera.main.transform.right;
		normRight=Camera.main.transform.right;

		normForward.Normalize();
		normBack.Normalize();
		normLeft.Normalize();
		normRight.Normalize();

		normBack.y=0;

		if(Input.GetKey(KeyCode.W)){
			rb.AddForce (cameraDir*speed);
		}
		if(Input.GetKey(KeyCode.S)){
			rb.AddForce (normBack*speed);
		}
//		if(Input.GetKey(KeyCode.A)){
//			rb.AddForce (normLeft*speed);
//		}
//		if(Input.GetKey(KeyCode.D)){
//			rb.AddForce (normRight*speed);
//		}
        //changing melt speed
        time = clock.seconds;
        //Debug.Log("Time:" + time);
        if (time % 30 == 0 && time > 0 && meltedTime < time)
        {
            meltedTime = time + 1;
            Debug.Log("Melt increased");
            meltSpeed += 0.2f;
        }

        //ball melting\\
        //transform.localScale -= new Vector3(0.0006f, 0.0006f, 0.0006f) * meltSpeed;

        SizeCheck();
    }
	void OnCollisionEnter(Collision pickups)
	{
        if (pickups.gameObject.tag != "Boundary")
        {
            pickups.collider.enabled = false;
            Destroy(pickups.gameObject.GetComponent<Rigidbody>());
            pickups.transform.parent = transform;
			if(pickups.collider.tag=="Sprinkle")
			{
                score += 150;
                transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
                //slowMulti=Mathf.Pow(spWeight,transform.childCount);
                //speed*=slowMulti;
            }
			if(pickups.collider.tag=="Chocolate")
			{
                score += 100;
                transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
                //slowMulti=Mathf.Pow(spWeight,transform.childCount);
				//speed*=slowMulti;
			}
            if (pickups.collider.tag == "Carrot")
            {
                score -= 100;
                transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
                //slowMulti=Mathf.Pow(spWeight,transform.childCount);
                //speed*=slowMulti;
            }

            //Debug.Log(speed);
            //transform.localScale += new Vector3(0.02f, 0.02f, 0.02f); 
        }
	}

    void SizeCheck()
    {
        if (transform.localScale.x < 0.2f)
        {
            isAlive = false;
            this.gameObject.SetActive(false); 
        }
    }
}