using UnityEngine;
using System.Collections;

public class instantiate : MonoBehaviour
{

    public Transform Spawn;
    public GameObject Bacteria;
    void OnTriggerEnter2D()
        {
            Instantiate(Bacteria, Spawn.position, Spawn.rotation);
        }
}