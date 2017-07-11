using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	public float speed = 10;
	public float tilt;
	public float fireDelta = 0.5f;
	public Boundary mBoundary;
	public GameObject mShot;
	public Transform mShotSpawn;

	private Rigidbody mRigidbody;
	private AudioSource mAudioSource;
	private float nextFire = 0.5f;

	// Use this for initialization
	void Start () {
		mRigidbody = GetComponent<Rigidbody> ();
		mAudioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireDelta;
			Instantiate (mShot, mShotSpawn.position, mShotSpawn.rotation);
			mAudioSource.Play ();
		}

	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		mRigidbody.velocity = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;

		mRigidbody.position = new Vector3(
			Mathf.Clamp(mRigidbody.position.x, mBoundary.xMin, mBoundary.xMax),
			0.0f,
			Mathf.Clamp(mRigidbody.position.z, mBoundary.zMin, mBoundary.zMax)
		);

		mRigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, mRigidbody.velocity.x * (-tilt));
	}
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}