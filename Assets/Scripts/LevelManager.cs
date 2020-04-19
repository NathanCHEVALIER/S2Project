using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.DemoParticle;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private float executionTime = 7.0f;
    private float playerTime;
    private bool running = false;
    private GameObject player;
    private NetworkPlayer NetPlayer;
    
    public Text gameStatus;
    public GameObject FinishZone;
    
    // Start is called before the first frame update
    void Start()
    {
        gameStatus.text = "Prêt ?";
        player = GameObject.FindWithTag("MyPlayer");
        NetPlayer = player.GetComponent<NetworkPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        executionTime -= Time.deltaTime;
        if (executionTime < -1.5f)
        {
            if (running)
            {
                gameStatus.text = "" + (-1 * executionTime);
            }
            else
            {
                gameStatus.text = "Terminé en " + (-1 * playerTime);
            }
        }
        else if (executionTime <= 0)
        {
            running = true;
            NetPlayer.enableRunning();
            gameStatus.text = "Partez !";
        } 
        else if (executionTime < 4)
        {
            gameStatus.text = "" + (int)executionTime;
        }
    }

    public void FinishLevel()
    {
        playerTime = executionTime;
        running = false;
        NetPlayer.enableRunning(running);
    }
}
