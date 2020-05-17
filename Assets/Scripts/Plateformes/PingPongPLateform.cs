using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongPLateform : MonoBehaviour
{
    public float start = 0f;
    public float speed = 2f;
    public float length = 3f;
         // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, length) + start, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
