using UnityEngine;
using System.Collections;

public class RedBloodCellScript : MonoBehaviour {

	private Rigidbody2D rb;
	private float moveMod; //modifies force applied on each FixedUpdate

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		moveMod = 2.375f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (moveMod*(new Vector2(-Random.value, 2*(Random.value-0.5f))));
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.CompareTag ("Player") && c.gameObject.GetComponent<PlayerController> ().infection >= 100.0f) {
			c.gameObject.GetComponent<PlayerController> ().score += 50;
			Destroy (gameObject);
		}
	}
}