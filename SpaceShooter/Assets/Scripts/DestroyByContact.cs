using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject Explosion;
	public GameObject PlayerExplosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (!other.CompareTag("boundary")) {
			Instantiate (Explosion, transform.position, transform.rotation);
			if (other.CompareTag("Player")) 
				Instantiate (PlayerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
