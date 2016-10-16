using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float movement_h;
	public float movement_v;
	public float infection;
	public bool isWrestling;
	public int lap_num;
	public int score;
	public int finalScore;
	public bool gameEnd;

	public float beginTime;
	public float wrestleTime;

	public Text infectionText;
	public Text scoreText;
	public Text gameOverText;
	public Text lapText;
	public Text finalScoreText;



	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		infection = 0.0f;
		lap_num = 0;
		SetInfectionText ();
		gameOverText.text = "";
		finalScoreText.text = "";
		SetScoreText ();
		SetLapText ();

	}

	void FixedUpdate ()
	{

		//if (isWrestling) {
			//Wrestle ();
		//}

		if (!gameEnd) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				movement_h = 2 * speed;

			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				movement_h = -(speed / 5);

			} else {
				movement_h = 0.0f;
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				movement_v = 1.5f * speed;

			} else if (Input.GetKey (KeyCode.DownArrow)) {
				movement_v = -1.5f * speed;

			} else {
				movement_v = 0.0f;
			}

			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (4.0f + movement_h, movement_v);

			score += 1;
			SetScoreText ();

		} else {
			finalScore = score;
			infectionText.text = "";
			lapText.text = "";
			SetFinalScoreText ();
			scoreText.text = "";
			gameOverText.text = "GAME OVER";
		}
	}

	void Wrestle ()
	{
		beginTime = (float)Time.time;
		int remainingWrestles = 10;
		while (remainingWrestles > 0) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				remainingWrestles -= 1;
			}
		}
		wrestleTime = (float)Time.time - beginTime;
		infection += 0.001f * wrestleTime;
		SetInfectionText ();
		isWrestling = false;
	}

	void SetInfectionText ()
	{
		string formatted_percentage = infection.ToString () + "%";
		infectionText.text = "% Infected: " + formatted_percentage;
	}

	void SetScoreText ()
	{
		scoreText.text = "Score: " + score.ToString();
	}

	void SetLapText ()
	{
		lapText.text = "Lap: " + lap_num.ToString();
	}

	void SetFinalScoreText ()
	{
		finalScoreText.text = "Final Score: " + finalScore.ToString();
	}


}
