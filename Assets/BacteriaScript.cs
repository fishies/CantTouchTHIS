using UnityEngine;
using System.Collections;

public class BacteriaScript : MonoBehaviour {

	private Rigidbody2D rb;
	private float moveMod; //modifies force applied on each FixedUpdate
	private Vector2 drift; //horizontal offset so we can constantly drift toward left

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		moveMod = 1.0f;
		drift.x = -0.75f;
		drift.y = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject[] cells = GameObject.FindGameObjectsWithTag ("RedBloodCell");
		GameObject target = GameObject.FindGameObjectWithTag ("Player");
		float closest = (target.transform.position-transform.position).magnitude;
		foreach (GameObject cell in cells) {
			float current = (cell.transform.position-transform.position).magnitude;
			if (current < closest) {
				closest = current;
				target = cell;
			}
		}
		rb.AddForce (drift+moveMod*((Vector2)(target.transform.position-transform.position)).normalized);
	}
}