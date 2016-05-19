using UnityEngine;
using System.Collections;

public class CAMController: MonoBehaviour {
	private Vector3 offset;
	private Vector3 desiredPos;
	public GameObject target;
	public float radius;
	public float rotateSpeed = 12;
	public float distance= 1;
	void Start () {
		offset=target.transform.position-transform.position;
		radius = 7;
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
		Debug.DrawRay(transform.position,transform.forward,Color.green);
		transform.LookAt(target.transform);
		transform.RotateAround (target.transform.position, Vector3.up, Input.GetAxis ("Mouse X") * radius);
//		if(Input.GetKey(KeyCode.D)){
//			orbit(false);
//		}
//		if(Input.GetKey(KeyCode.A)){
//			orbit(true);
//		}

	}
//	void orbit(bool spinLeft){
//		float step=rotateSpeed*Time.deltaTime;
//		float orbitCirc= 2f*distance*Mathf.PI;
//		float distanceRad=(rotateSpeed/orbitCirc)*2*Mathf.PI;
//		if(spinLeft){
//			transform.RotateAround(target.transform.position,Vector3.up,-distanceRad);
//		}
//		else{
//			transform.RotateAround(target.transform.position,Vector3.up,distanceRad);
//		}
//	}


}