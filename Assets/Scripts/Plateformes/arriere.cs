using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arriere : MonoBehaviour
{
	public Vector3 safepos;
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject)
		{
			other.transform.position = safepos ;	

		}
		
	}
}
