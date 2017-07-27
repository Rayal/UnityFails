using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public HazardInfo hazardInfo;

	private int scoreValue;
	private bool gameOver = false;
	private bool restart = false;

	// Use this for initialization
	void Start ()
	{
		restartText.text = "";
		gameOverText.text = "";
		scoreValue = 0;
		updateScore ();
		StartCoroutine (spawnWaves ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
				//SceneManager.LoadScene (SceneManager.GetActiveScene ().ToString ());
			}
		}
	}

	IEnumerator spawnWaves ()
	{
		yield return new WaitForSeconds (hazardInfo.startWait);
		while (true)
		{
			for (int i = 0; i < hazardInfo.hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (
					Random.Range (-hazardInfo.spawnValues.x, hazardInfo.spawnValues.x),
					hazardInfo.spawnValues.y,
					hazardInfo.spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazardInfo.Hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (hazardInfo.spawnWait);
			}
			yield return new WaitForSeconds (hazardInfo.waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}

	public void addScore (int newScore)
	{
		scoreValue += newScore;
		updateScore ();
	}

	void updateScore ()
	{
		scoreText.text = "Score: " + scoreValue;
	}

	public void setGameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}

[System.Serializable]
public class HazardInfo{
	public GameObject Hazard;
	public Vector3 spawnValues;
	public int hazardCount = 1;
	public float spawnWait;
	public float startWait = 3f;
	public float waveWait = 3f;
}