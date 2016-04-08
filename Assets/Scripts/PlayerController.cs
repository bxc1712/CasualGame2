using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private float spWeight;
	private float chWeight;
	private float slowMulti;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		spWeight=0.99f;
		chWeight=0.95f;
	}
	void FixedUpdate()
    {
		float moveHorizontal=Input.GetAxis("Horizontal");
		float moveVertical=Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*speed);
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
				slowMulti=Mathf.Pow(spWeight,transform.childCount);
				speed*=slowMulti;
			}
			if(pickups.collider.tag=="Chocolate")
			{
				slowMulti=Mathf.Pow(spWeight,transform.childCount);
				speed*=slowMulti;
			}
			Debug.Log(speed);
		}
	}
}