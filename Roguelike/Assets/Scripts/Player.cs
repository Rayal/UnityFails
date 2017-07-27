using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject {

	public int wallDamage = 1;
	public int pointsForFood = 10;
	public int pointsForSoda = 20;
	public float restartLevelDelay = 1f;
	public Text foodText;

	private Animator animator;
	private int food;


	// Use this for initialization
	protected override void Start ()
	{
		animator = GetComponent<Animator> ();
		Debug.Log ("Enabled");
		Debug.Log ("Food: " + GameManager.instance.playerFoodPoints);
		food = GameManager.instance.playerFoodPoints;
		foodText.text = "Food: " + food;

		base.Start ();
	}

	private void OnDisable ()
	{
		Debug.Log ("Disabled");
		GameManager.instance.playerFoodPoints = food;
		Debug.Log ("Food: " + GameManager.instance.playerFoodPoints);
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.playersTurn)
			return;

		int horizontal = 0;
		int vertical = 0;

		horizontal = (int) Input.GetAxisRaw ("Horizontal");
		vertical = (int) Input.GetAxisRaw ("Vertical");

		if (horizontal != 0)
			vertical = 0;

		if (vertical != 0 || horizontal != 0)
			AttemptMove<Wall> (horizontal, vertical);
	}

	protected override void AttemptMove<T> (int xDir, int yDir)
	{
		food--;
		foodText.text = "Food: " + food;

		base.AttemptMove<T> (xDir, yDir);

		RaycastHit2D hit;

		CheckIfGameOver ();

		GameManager.instance.playersTurn = false;
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Exit")
		{
			Invoke ("Restart", restartLevelDelay);

			enabled = false;
		}
		else if (other.tag == "Food")
		{
			food += pointsForFood;
			foodText.text = "+" + pointsForFood + " Food: " + food;
			other.gameObject.SetActive (false);
		}
		else if (other.tag == "Soda")
		{
			food += pointsForSoda;
			foodText.text = "+" + pointsForSoda + " Food: " + food;
			other.gameObject.SetActive (false);
		}
	}

	protected override void OnCantMove<T> (T component)
	{
		Wall hitWall = component as Wall;
		hitWall.DamageWall (wallDamage);
		animator.SetTrigger ("playerChop");
	}

	private void Restart()
	{
		SceneManager.LoadScene (0);
	}

	public void LoseFood (int loss)
	{
		animator.SetTrigger ("playerHit");
		food -= loss;
		foodText.text = "- " + loss + " Food: " + food;
		CheckIfGameOver ();
	}

	private void CheckIfGameOver ()
	{
		if (food <= 0)
			GameManager.instance.GameOver ();
	}
}
