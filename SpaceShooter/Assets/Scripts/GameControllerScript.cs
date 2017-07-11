using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	public GameObject Hazard;
	public Vector3 spawnValues;
	public int hazardCount = 1;
	public float spawnWait;
	public float startWait = 3f;
	public float waveWait = 3f;

	// Use this for initialization
	void Start () {
		StartCoroutine (spawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (Hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
