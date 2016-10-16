using UnityEngine;
using System.Collections;

public class StickBacteria : MonoBehaviour {


    void OnCollisionEnter(Collision Col)
    {

        var joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = Col.rigidbody;
    }
}
