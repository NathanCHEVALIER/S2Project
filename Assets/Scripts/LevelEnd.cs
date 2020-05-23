using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        GameObject player = GameObject.FindWithTag("MyPlayer");
        GameObject manager = GameObject.FindWithTag("LevelManager");
        LevelManager LevelManager = manager.GetComponent<LevelManager>();

        if (col.gameObject == player)
        {
            LevelManager.FinishLevel();
        }
    }
}
