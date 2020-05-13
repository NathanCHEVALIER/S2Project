using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string LevelSuivant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider Other)
    {
        if(Other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(LevelSuivant);
        }
    }
}

