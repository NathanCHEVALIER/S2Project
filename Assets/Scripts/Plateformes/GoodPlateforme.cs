using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPlateforme : MonoBehaviour
{
	public GameObject Cube;
	public int num;
	public int number;

	void Update()
	{
		num = Cube.GetComponent<ChangeColor>().num;
		if (gameObject.GetComponent<Renderer>().material.color == Color.blue)
		{
			number = 1;
		}
		if (gameObject.GetComponent<Renderer>().material.color == Color.cyan)
		{
			number = 2;
		}

		if (gameObject.GetComponent<Renderer>().material.color == Color.green)
		{
			number = 3;
		}

		if (gameObject.GetComponent<Renderer>().material.color == Color.HSVToRGB(Convert.ToSingle(255), Convert.ToSingle(167), Convert.ToSingle(0)))
		{
			number = 4;
		}
		if (gameObject.GetComponent<Renderer>().material.color == Color.red)
		{
			number = 5;
		}
		if (gameObject.GetComponent<Renderer>().material.color == Color.white)
		{
			number = 6;
		}
		if (gameObject.GetComponent<Renderer>().material.color == Color.yellow)
		{
			number = 7;
		}
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
		Cube.GetComponent<ChangeColor>().enabled = false;
	}
	
	private IEnumerator OnCollisionExit(Collision other)
	{
		Cube.GetComponent<ChangeColor>().enabled = true;
		yield return new WaitForSeconds(2);
		gameObject.GetComponent<Collider>().isTrigger = false;
	}
}
