using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPlateforme : MonoBehaviour
{
	public GameObject target1;
	Color c;
	public int num;
	int number;
	
	void Start()
	{
		num = target1.GetComponent<ChangeColor>().num;
		if (gameObject.GetComponent<SkinnedMeshRenderer>().material.color == Color.blue)
			number = 0;
		if (gameObject.GetComponent<SkinnedMeshRenderer>().material.color == Color.cyan)
			number = 1;
		if (gameObject.GetComponent<SkinnedMeshRenderer>().material.color == Color.green)
			number = 2;
		if (gameObject.GetComponent<SkinnedMeshRenderer>().material.color == Color.HSVToRGB(Convert.ToSingle(255),Convert.ToSingle(167), Convert.ToSingle(0)))
			number = 3;
		if (gameObject.GetComponent<SkinnedMeshRenderer>().material.color == Color.red)
			number = 4;
		if (gameObject.GetComponent<SkinnedMeshRenderer>().material.color == Color.white)
			number = 5;
		if (gameObject.GetComponent<SkinnedMeshRenderer>().material.color == Color.yellow)
			number = 6;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (num == number)
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
