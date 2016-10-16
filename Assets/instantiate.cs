using UnityEngine;
using System.Collections;

public class instantiate : MonoBehaviour
{

    public Transform Spawn;
    public GameObject Bacteria;
    void Start()
    {
		InvokeRepeating("makeenemy", 0f, Random.Range(2.25f, 5.0f));
    }

	void makeenemy()
	{
		Instantiate(Bacteria, Spawn.position, Spawn.rotation);

	}
}