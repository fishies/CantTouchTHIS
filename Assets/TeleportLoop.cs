using UnityEngine;
using System.Collections;

public class TeleportLoop : MonoBehaviour {

	public ArrayList RBC;
	public ArrayList WBC;
	public ArrayList BAC;
	public ArrayList spawners;
    public Transform Spawn;
    public GameObject spawner_cell;
    public PlayerController player;
	public GameObject player_cell;
	public bool initial_loop = true;

    public float difficulty_num = 0.25f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            player_cell = GameObject.FindGameObjectWithTag("Player");
			if (initial_loop) {
				spawners = GameObject.FindGameObjectsWithTag ("Initial Spawner");
				for (var i = 0; i < spawners.Length; i++)
					Destroy (spawners [i]);
				initial_loop = false;
			}
			RBC =  GameObject.FindGameObjectsWithTag ("RedBloodCell");
			for(var i = 0 ; i < RBC.Length ; i ++)
				Destroy(RBC[i]);
			RBC =  GameObject.FindGameObjectsWithTag ("WhiteBloodCell");
			for(var i = 0 ; i < WBC.Length ; i ++)
				Destroy(WBC[i]);
			RBC =  GameObject.FindGameObjectsWithTag ("Bacteria");
			for(var i = 0 ; i < BAC.Length ; i ++)
				Destroy(BAC[i]);
            player.wigglesRemaining = 0;
            Destroy(player.GetComponent<FixedJoint2D>());
            player_cell.transform.position = new Vector2(0, other.transform.position.y);
            player.lap_num += 1;
            player.lapText.text = "Lap: " + player.lap_num;

            InvokeRepeating("spawn_cells", 0f, Random.Range(2.25f, 5.0f));
            if (player.lap_num % 2 == 0)
            {
                diff_num -= 0.25f;
            }
        }
    }

    void spawn_cells()
    {
		Instantiate(spawner_cell, Spawn.position, Spawn.rotation);

    }

}


