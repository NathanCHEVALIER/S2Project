using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetourDepart : MonoBehaviour
{
    public Transform ZoneStart;
    
    void OnTriggerEnter(Collider Other)
    {
        if(Other.gameObject.tag == "Player")
        {
            Other.gameObject.transform.position = ZoneStart.transform.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
