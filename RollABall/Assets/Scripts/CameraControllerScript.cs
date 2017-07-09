using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour {

	public GameObject playerObject;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - playerObject.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = playerObject.transform.position + offset;
	}
}
