using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public int BaseLevel = 4;

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + BaseLevel);
    }    
    public void BackMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void BackLevels()
    {
        SceneManager.LoadScene(2);
    }
}
