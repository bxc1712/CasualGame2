using UnityEngine;
using System.Collections;

public class CAMController: MonoBehaviour {
	private Vector3 offset;
	private Vector3 desiredPos;
	public GameObject target;
	public float radius;
	public float rotateSpeed = 0.5f;
	public float distance= 1;
	void Start () {
		offset=target.transform.position-transform.position;
		radius = 5;
	}
	void LateUpdate () {
//		Vector3 desiredPosition = target.transform.position + offset;
//		transform.position=desiredPosition;
		//offset=target.transform.position-transform.position;
		desiredPos = transform.position;
		desiredPos.x-= desiredPos.x+offset.x;
		desiredPos.z-= desiredPos.z+offset.z;
		desiredPos=desiredPos.normalized * radius + target.transform.position;
		//Debug.Log(desiredPos.y+"desired");
		//Debug.Log(offset.y+"offset");
		//Debug.Log(offset);
		transform.position = Vector3.MoveTowards(transform.position, desiredPos, Time.deltaTime * rotateSpeed);
		//Debug.DrawRay(transform.position,offset,Color.green);
		transform.LookAt(target.transform.position);
		if(Input.GetKey(KeyCode.D)){
			orbit(false);
		}
		if(Input.GetKey(KeyCode.A)){
			orbit(true);
		}

		//transform.RotateAround(target.transform.position,Vector3.up,Input.GetAxis("Mouse X")*rotateSpeed);
//		transform.position = desiredPosition;
//		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
//		target.transform.Rotate (0, horizontal, 0);
//
//		float desiredAngle = target.transform.eulerAngles.y;
//		Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
//		transform.position = target.transform.position - (rotation * offset);
//		transform.LookAt(target.transform);
//		transform.position = player.transform.position + offset;

	}
	void orbit(bool spinLeft){
		float step=rotateSpeed*Time.deltaTime;
		float orbitCirc= 2f*distance*Mathf.PI;
		float distanceRad=(rotateSpeed/orbitCirc)*2*Mathf.PI;
		if(spinLeft){
			transform.RotateAround(target.transform.position,Vector3.up,-distanceRad);
		}
		else{
			transform.RotateAround(target.transform.position,Vector3.up,distanceRad);
		}
	}


}