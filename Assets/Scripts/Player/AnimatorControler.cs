using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{

    public Animator animator;
    float InputY;
    float InputX;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (PhotonNetwork.connected == true && PhotonView.isMine)
        {
            return;
        }*/
        InputY = Input.GetAxis("Jump");
        InputX = Input.GetAxis("Horizontal");
        animator.SetFloat("InputY", InputY);
        animator.SetFloat("InputX", InputX);
    }
}
