using UnityEngine;
using System.Collections;

public class destroystuff : MonoBehaviour
{

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("WhiteBloodCell"))
            Destroy(col.gameObject);
        else if (col.gameObject.CompareTag("Bacteria"))
            Destroy(col.gameObject);
        else if (col.gameObject.CompareTag("RedBloodCell"))
            Destroy(col.gameObject);

    }

}