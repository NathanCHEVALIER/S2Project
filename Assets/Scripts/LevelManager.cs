using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.DemoParticle;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private float executionTime = 7.0f;
    private bool running = false;
    private GameObject player;
    private NetworkPlayer NetPlayer;
    
    public Text gameStatus;
    
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
        if (executionTime < 0)
        {
            gameStatus.text = "Run & Win !";
            if (!running)
            {
                running = true;
                NetPlayer.enableRunning();
            }
        } 
        else if (executionTime < 4)
        {
            gameStatus.text = "Run in " + (int)executionTime;
        }
        
    }
}
