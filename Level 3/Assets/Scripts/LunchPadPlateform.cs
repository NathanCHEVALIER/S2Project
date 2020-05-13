using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchPadPlateform : MonoBehaviour
{
    public Vector3 _force;
 
    public void OnCollisionEnter(Collision col)
    {
        print("Collision Detected");
        col.rigidbody.AddForce(_force);
    }
    public void OnCollisionExit(Collision collision)
    {
        collision.rigidbody.AddForce( 0,0,0);
    }

}
