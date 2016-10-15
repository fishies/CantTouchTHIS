using UnityEngine;
using System.Collections;

public class destroystuff : MonoBehaviour
{

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D col)
    {

        {
            Destroy(col.gameObject);
        }
    }

}