using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongY : MonoBehaviour
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
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, length) + start, transform.position.z);
    }
}

