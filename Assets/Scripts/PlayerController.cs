using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject sprinkle;

	private float spWeight;
	private float slowMulti;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		spWeight=0.99f;
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
		if(pickups.gameObject.tag=="Pickup")
		{
			pickups.collider.enabled=false;
			Destroy(pickups.gameObject.GetComponent<Rigidbody>());
			pickups.transform.parent=transform;

			if(sprinkle.name=="Sprinkle")
			{
				slowMulti=Mathf.Pow(spWeight,transform.childCount);
				speed*=slowMulti;
				Debug.Log(speed);
			}
		}
	}
}