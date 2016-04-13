using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private float spWeight;
	private float chWeight;
	private float slowMulti;
	private Rigidbody rb;

    int score;

    bool isAlive;

	void Start()
	{
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

        transform.localScale -= new Vector3(0.0003f, 0.0003f, 0.0003f);

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
                
                //slowMulti=Mathf.Pow(spWeight,transform.childCount);
				//speed*=slowMulti;
			}
			if(pickups.collider.tag=="Chocolate")
			{
                score += 100;
                
                //slowMulti=Mathf.Pow(spWeight,transform.childCount);
				//speed*=slowMulti;
			}
            //Debug.Log(speed);
            transform.localScale += new Vector3(0.02f, 0.02f, 0.02f); 
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