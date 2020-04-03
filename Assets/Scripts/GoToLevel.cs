using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public int BaseLevel = 2;

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + BaseLevel);
    }
}
