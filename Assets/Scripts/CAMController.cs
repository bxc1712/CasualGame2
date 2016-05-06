using UnityEngine;
using System.Collections;

public class CAMController: MonoBehaviour {
	private Vector3 offset;
	public GameObject target;
	//public float rotateSpeed = 5;
	private float mouseX;
	private float mouseY;

	void Start () {
		offset = transform.position - target.transform.position;
	}
	void LateUpdate () {
		camerRotate();


		Vector3 desiredPosition = target.transform.position + offset;
		transform.position=desiredPosition;
//		transform.position = desiredPosition;
//		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
//		target.transform.Rotate (0, horizontal, 0);
//
//		float desiredAngle = target.transform.eulerAngles.y;
//		Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
//		transform.position = target.transform.position - (rotation * offset);
//		transform.LookAt(target.transform);
//		transform.position = player.transform.position + offset;

		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;
	}

	void camerRotate(){
		var ease = 10f;
		if (Input.GetMouseButton (0)) {
			if (Input.mousePosition.x != mouseX) {
				var cameraRotationY = (mouseX-Input.mousePosition.x) * ease * Time.deltaTime;
				this.transform.Rotate (0, cameraRotationY, 0);
			}
			if(Input.mousePosition.y != mouseY){
				var cameraRotationX = (Input.mousePosition.y-mouseY) * ease * Time.deltaTime;
				this.transform.Rotate (cameraRotationX, 0, 0);
			}
		}
	}
}