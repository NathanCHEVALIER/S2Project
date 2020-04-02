using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    int BaseLevel = 1;

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + BaseLevel);
    }
    public void NextPage()
    {

    }

    public void PreviousPage()
    {

    }
}
