using UnityEngine;
using System.Collections;

public class TeleportLoop : MonoBehaviour {

	public PlayerController player;
	public GameObject blood_cell;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player"))
        {
            blood_cell = GameObject.FindGameObjectWithTag("Player");
            player.wigglesRemaining = 0;
            Destroy(player.GetComponent<FixedJoint2D>());
            blood_cell.transform.position = new Vector2(0, other.transform.position.y);
            player.lap_num += 1;
            player.lapText.text = "Lap: " + player.lap_num;
        }
	}
}
