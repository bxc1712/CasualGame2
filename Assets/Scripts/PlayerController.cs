using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
    //how fast the ball melts
    public float meltSpeed;

	private float spWeight;
	private float chWeight;
	private float slowMulti;
	private Rigidbody rb;

    public int score;

    bool isAlive;

	void Start()
	{
        meltSpeed = 1;
		rb = GetComponent<Rigidbody>();
		spWeight=0.99f;
		chWeight=0.95f;

        score = 0;

        isAlive = true;
	}
	void FixedUpdate()
    {
		float moveHorizontal=Input.GetAxis("Horizontal");
		float moveVertical=Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*speed);

        ///ball melting\\\
        transform.localScale -= new Vector3(0.0006f, 0.0006f, 0.0006f) * meltSpeed;

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