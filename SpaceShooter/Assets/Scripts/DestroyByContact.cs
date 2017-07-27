using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue = 5;
	public GameObject Explosion;
	public GameObject PlayerExplosion;

	private GameControllerScript gameControllerScript;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
			gameControllerScript = gameControllerObject.GetComponent<GameControllerScript> ();
		else
			Debug.Log ("Cannot find GameControllerScript");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("boundary"))
			return;
		Instantiate (Explosion, transform.position, transform.rotation);
		if (other.CompareTag ("Player"))
		{
			Instantiate (PlayerExplosion, other.transform.position, other.transform.rotation);
			gameControllerScript.setGameOver ();
		}
		gameControllerScript.addScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
