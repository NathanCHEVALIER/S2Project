using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPlateforme : MonoBehaviour
{
	public Transform target1;

	private void OnCollisionEnter(Collision other)
	{
		if (target1.GetComponent<Renderer>().material.color == gameObject.GetComponent<Renderer>().material.color)
		{
			gameObject.GetComponent<Collider>().isTrigger = false;
		}
		else
		{
			gameObject.GetComponent<Collider>().isTrigger = true;
		}
	}

	private void OnCollisionStay(Collision other)
	{
		target1.GetComponent<ChangeColor>().enabled = false;
	}
	
	private void OnCollisionExit(Collision other)
	{
		target1.GetComponent<ChangeColor>().enabled = true;
	}
}
