using UnityEngine;
using System.Collections;

public class CAMController: MonoBehaviour {
	public GameObject player;
	
	private Vector3 offset;
	private GameObject target;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		target=GameObject.Find("Snowball");
		transform.LookAt(target.transform);
	}
	
	void LateUpdate () {
		transform.position = player.transform.position + offset;
		Debug.Log (offset);
	}
}