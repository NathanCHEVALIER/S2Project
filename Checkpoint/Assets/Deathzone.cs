using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

public class Deathzone : MonoBehaviour {

	public Vector3 respawnPositions;
	public Transform target;
	public Color color;
	public int delta = 0;

	private void Start()
	{
		color = target.gameObject.GetComponent<Renderer>().material.color;
	}

	public void ColorGrey()
	{
		target.gameObject.GetComponent<Renderer>().material.color = Color.grey;
	}

	public void NormalColor()
	{
		target.gameObject.GetComponent<Renderer>().material.color = color;
	}

	public void NewPos()
	{
		ColorGrey();
		Invoke("NormalColor", 0.2f);
		target.transform.position = respawnPositions;
	}

	void OnCollisionEnter (Collision other) 
	{
		if (target.transform.gameObject.tag == "Player")
		{
			ColorGrey();
			Invoke("NormalColor", 0.2f);
			Invoke("NewPos", 0.4f);
		}
	}
}
