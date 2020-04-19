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
    
    public Text gameTimer;
    public Text gameCountdown;
    public GameObject FinishZone;
    
    // Start is called before the first frame update
    void Start()
    {
        gameCountdown.text = "Prêt ?";
        player = GameObject.FindWithTag("MyPlayer");
        NetPlayer = player.GetComponent<NetworkPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        executionTime -= Time.deltaTime;
        
        if (executionTime < -1.5f && !running)
        {
            gameCountdown.text = "Terminé !\n" + time2str(playerTime);
        }
        else if (executionTime <= 0)
        {
            if (!running)
            {
                running = true;
                NetPlayer.enableRunning();
            }

            if (executionTime > -1.5f)
            {
                gameCountdown.text = "Partez !";
            }
            else
            {
                gameCountdown.text = "";
            }
            gameTimer.text = "" + time2str(executionTime);
        }
        else if (executionTime < 4)
        {
            gameCountdown.text = "" + (int)executionTime;
        }
    }

    public void FinishLevel()
    {
        playerTime = executionTime;
        running = false;
        NetPlayer.enableRunning(running);
    }

    private string time2str(float time)
    {
        int decPart = (int) -time;
        int floatPart = (int)(-time * 100f) % 100;

        return decPart + ":" + floatPart;
    }
}
