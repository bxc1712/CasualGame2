using UnityEngine;
using System.Collections;

public class CAMController: MonoBehaviour {
	public GameObject player;
	
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () {
		transform.position = player.transform.position + offset;
		Debug.Log (offset);
	}
}