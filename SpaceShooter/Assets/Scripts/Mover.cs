using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed = 10;
	private Rigidbody mRigidbody;

	// Use this for initialization
	void Start () {
		mRigidbody = GetComponent<Rigidbody> ();
		mRigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
