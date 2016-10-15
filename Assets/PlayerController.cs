using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float movement_h;
	public float movement_v;
	public float infection;
	public bool isWrestling;

	public float beginTime;
	public float wrestleTime;


	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{

		//if (isWrestling) {
			//Wrestle ();
		//}

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

		this.GetComponent<Rigidbody> ().velocity = new Vector2 (4.0f + movement_h, movement_v);

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
		isWrestling = false;
	}



}
