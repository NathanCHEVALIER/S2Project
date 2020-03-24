using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvmt : MonoBehaviour
{
    public float moveSpeed = 4f;
    private float sprintSpeed = 6f;
    public float jumpSpeed = 5f;
    private bool IsGrounded;

    void OnCollisionStay(Collision collisionInfo)
    {
        IsGrounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        IsGrounded = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(0f, 0f, moveSpeed * horizontal * Time.deltaTime);
        }
        /*else
        {
            float horizontal = Input.GetAxis("Vertical");
            transform.Translate(moveSpeed * horizontal * Time.deltaTime, 0f, 0f);
        } */

        if (Input.GetKey(KeyCode.LeftShift) && IsGrounded)

        {
            moveSpeed = sprintSpeed;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 4f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpSpeed, 0f), ForceMode.Impulse);
        }

    }
}