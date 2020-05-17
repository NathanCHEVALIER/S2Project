using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    public float slow = 1f;
    private float normal = 4f;
    public Transform Player;
    void OnCollisionEnter (Collision collision)
    {
        Player.GetComponent<PlayerMvmt>().moveSpeed = slow;
    }
    void OnCollisionExit (Collision other)
    {
        Player.GetComponent<PlayerMvmt>().moveSpeed = normal;
    }
}
