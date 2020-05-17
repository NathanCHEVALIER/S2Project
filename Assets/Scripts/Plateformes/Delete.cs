using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{  
    public void OnCollisionEnter(Collision collision)
    {
        Invoke("Unactive", 0.5f);
    }
    
    public void Unactive()
    {
        this.gameObject.SetActive(false);
        Invoke("Active", 10f);
    }
    public void Active()
    {
        this.gameObject.SetActive(true);
    }
}
