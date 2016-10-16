using UnityEngine;
using System.Collections;

public class TeleportLoop : MonoBehaviour {
    public Transform Spawn;
    public GameObject Bacteria;
    public PlayerController player;
	public GameObject blood_cell;
    public float diff_num = 0.25f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            blood_cell = GameObject.FindGameObjectWithTag("Player");
            player.wigglesRemaining = 0;
            Destroy(player.GetComponent<FixedJoint2D>());
            blood_cell.transform.position = new Vector2(0, other.transform.position.y);
            player.lap_num += 1;
            player.lapText.text = "Lap: " + player.lap_num;

            InvokeRepeating("makeenemy", 0f, Random.Range(2.5f, 5.0f));
            if (player.lap_num % 2 == 0)
            {
                diff_num -= 0.25f;
            }
        }
    }

    void makeenemy()
    {
        Instantiate(Bacteria, Spawn.position, Spawn.rotation);

    }

}


