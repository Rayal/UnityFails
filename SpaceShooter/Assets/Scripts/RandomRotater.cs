using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour {

	public float tumble = 1;

	private Rigidbody mRigidbody;

	// Use this for initialization
	void Start () {
		mRigidbody = GetComponent<Rigidbody> ();

		mRigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
