using UnityEngine;
using System.Collections;

public class WhiteBloodCellScript : MonoBehaviour {

	private Rigidbody2D rb;
	private float moveMod; //modifies force applied on each FixedUpdate
	private Vector2 drift; //horizontal offset so we can constantly drift toward left

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		moveMod = 0.75f;
		drift.x = -.625f;
		drift.y = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		GameObject target = GameObject.FindGameObjectWithTag ("Player");
		if (target.GetComponent<PlayerController>().infection < 100.0f) {
			GameObject[] cells = GameObject.FindGameObjectsWithTag ("Bacteria");
			float closest = (target.transform.position - transform.position).magnitude;
			foreach (GameObject cell in cells) {
				float current = (cell.transform.position - transform.position).magnitude;
				if (current < closest) {
					closest = current;
					target = cell;
				}
			}
		}
		rb.AddForce (drift+moveMod*((Vector2)(target.transform.position-transform.position)).normalized);
	}
}
