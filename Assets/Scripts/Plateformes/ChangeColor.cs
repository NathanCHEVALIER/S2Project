using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeColor : MonoBehaviour
{
	public Material[] material = new Material[7];
	public int num;
	public int number;
	void Update()
	{
		if (Input.GetMouseButtonDown(2))
		{
			number = Random.Range(0, material.Length);
			gameObject.GetComponent<SkinnedMeshRenderer>().material = material[number];
			if (gameObject.GetComponent<SkinnedMeshRenderer>().material == material[0])
				num = 0;
			if (gameObject.GetComponent<SkinnedMeshRenderer>().material == material[1])
				num = 1;
			if (gameObject.GetComponent<SkinnedMeshRenderer>().material == material[2])
				num = 2;
			if (gameObject.GetComponent<SkinnedMeshRenderer>().material == material[3])
				num = 3;
			if (gameObject.GetComponent<SkinnedMeshRenderer>().material == material[4])
				num = 4;
			if (gameObject.GetComponent<SkinnedMeshRenderer>().material == material[5])
				num = 5;
			if (gameObject.GetComponent<SkinnedMeshRenderer>().material == material[6])
				num = 6;
			if (gameObject.GetComponent<SkinnedMeshRenderer>().material == material[7])
				num = 7;
		}
	}
}
