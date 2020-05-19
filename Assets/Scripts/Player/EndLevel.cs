using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public int next_level_index;
    public int menu_indexs;
    public GameObject end_canvas;

    private void Awake()
    {
        next_level_index = SceneManager.GetActiveScene().buildIndex + 1;
        menu_indexs = 4;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Finish")
        {
            Time.timeScale = 0f;
            if(next_level_index-menu_indexs > PlayerPrefs.GetInt("levelReached"))
            {
                PlayerPrefs.SetInt("levelReached", next_level_index - menu_indexs);                
            }
            end_canvas.SetActive(true);
            
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(GetComponent<EndLevel>().next_level_index);
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
