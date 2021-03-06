﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float movement_h;
	public float movement_v;
	public float infection;
	public int wigglesRemaining;
	public int lap_num;
	public int score;
	public int finalScore;
	public bool gameEnd;

	public Text infectionText;
	public Text scoreText;
	public Text gameOverText;
	public Text lapText;
	public Text finalScoreText;

	public Sprite rbc2;
	public Sprite rbc3;

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private Animator animator;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponentInChildren<SpriteRenderer> ();
		animator = GetComponentInChildren<Animator> ();
		infection = 0.0f;
		lap_num = 0;
		SetInfectionText ();
		gameOverText.text = "";
		finalScoreText.text = "";
		SetScoreText ();
		SetLapText ();
	}

	void Update ()
	{
		if (!gameEnd) {
			SetScoreText ();
			if (wigglesRemaining > 0) {
				infection += 0.125f;
				SetInfectionText ();
				if (infection >= 100.0f) {
					animator.SetInteger ("infectstate", 2);
					sr.sprite = rbc3;
					wigglesRemaining = 0;
				} else if (infection >= 50.0f) {
					animator.SetInteger ("infectstate", 1);
					sr.sprite = rbc2;
				}
				if (Input.GetKey (KeyCode.LeftArrow) && wigglesRemaining % 2 == 0)
					wigglesRemaining -= 1;
				else if (Input.GetKey (KeyCode.RightArrow) && wigglesRemaining % 2 == 1)
					wigglesRemaining -= 1;
			} else if (gameObject.GetComponent<FixedJoint2D> () != null) {
				Destroy (gameObject.GetComponent<FixedJoint2D> ().connectedBody.gameObject);
				Destroy (gameObject.GetComponent<FixedJoint2D> ());
			}
		} else {
			finalScore = score;
			infectionText.text = "";
			lapText.text = "";
			SetFinalScoreText ();
			scoreText.text = "";
			gameOverText.text = "GAME OVER";
		}
	}

	void FixedUpdate ()
	{
		if (!gameEnd) {
			if (Input.GetKey (KeyCode.RightArrow))
				movement_h = 2 * speed;
			else if (Input.GetKey (KeyCode.LeftArrow))
				movement_h = -(speed / 5);
			else
				movement_h = 0.0f;

			if (Input.GetKey (KeyCode.UpArrow))
				movement_v = 1.5f * speed;
			else if (Input.GetKey (KeyCode.DownArrow))
				movement_v = -1.5f * speed;
			else
				movement_v = 0.0f;

			rb.velocity = new Vector2 (4.0f + movement_h, movement_v);

			score += 1;
		}
	}

	void SetInfectionText ()
	{
		if (infection >= 100.0f)
			infectionText.text = "100% Infected";
		else
			infectionText.text = infection.ToString () + "% Infected";
	}

	void SetScoreText ()
	{
		scoreText.text = "Score: " + score.ToString ();
	}

	void SetLapText ()
	{
		lapText.text = "Lap: " + lap_num.ToString ();
	}

	void SetFinalScoreText ()
	{
		finalScoreText.text = "Final Score: " + finalScore.ToString ();
	}


}