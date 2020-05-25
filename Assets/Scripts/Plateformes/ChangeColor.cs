using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeColor : MonoBehaviour
{
	public Material[] material = new Material[7];
	public int num = 0;
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if(num == 0)
				gameObject.GetComponent<SkinnedMeshRenderer>().material = material[material.Length - 1];
			gameObject.GetComponent<SkinnedMeshRenderer>().material = material[num - 1];
			num -= 1;
		}
		if (Input.GetMouseButtonDown(1))
		{
			if(num == material.Length - 1)
				gameObject.GetComponent<SkinnedMeshRenderer>().material = material[0];
			gameObject.GetComponent<SkinnedMeshRenderer>().material = material[num + 1];
			num += 1;
		}
	}
}
