using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBlocker : MonoBehaviour
{
    public Button[] LevelList;

    private void Awake()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < LevelList.Length; i++)
        {
            if(i+1 > levelReached)
            {
                LevelList[i].interactable = false;
            }
            
        }   
    }
}
