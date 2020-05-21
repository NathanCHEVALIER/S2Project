using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_jump : MonoBehaviour {

    float vitesse = 0.05f;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float rayDistance;
    [SerializeField]
    private LayerMask layers;
    private bool grounded;

    // Use this for initialization
    void Start ()
    {
		
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            right();
        }
        if (Input.GetKey("left") || Input.GetKey("q"))
        {
            left();
        }
        if (Input.GetKey("up") || Input.GetKey("z"))
        {
            up();
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            down();
        }
        if (Input.GetKey("space"))
        {
            Jump();
        }
    }

    void left()
    {
        transform.Translate(-vitesse, 0, 0);
    }

    void right()
    {
        transform.Translate(vitesse, 0, 0);
    }

    void up()
    {
        transform.Translate(0, 0, vitesse);
    }

    void down()
    {
        transform.Translate(0, 0, -vitesse);
    }

    void Jump()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * rayDistance, Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, rayDistance, layers))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}