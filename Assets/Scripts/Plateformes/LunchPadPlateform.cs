using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchPadPlateform : MonoBehaviour
{
    public Vector3 _force;
 
    public void OnCollisionEnter(Collision col)
    {
        col.rigidbody.AddForce(_force);
    }
    

}
