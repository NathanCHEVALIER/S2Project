using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public int BaseLevel = 3;

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + BaseLevel);
    }    
    public void BackMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
    public void BackLevels()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
