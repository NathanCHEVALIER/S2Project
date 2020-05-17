using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public int next_level_index;
    public int menu_indexs;
    private void Awake()
    {
        next_level_index = SceneManager.GetActiveScene().buildIndex + 1;
        menu_indexs = 2;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Finish")
        {
            if(next_level_index-menu_indexs > PlayerPrefs.GetInt("levelReached"))
            {
                PlayerPrefs.SetInt("levelReached", next_level_index - menu_indexs);                
            }
            SceneManager.LoadScene(next_level_index);

        }
    }
}
