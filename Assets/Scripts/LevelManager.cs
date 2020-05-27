using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.DemoParticle;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private float executionTime = 7.0f;
    private float playerTime;
    private bool running = false;
    private GameObject player;
    private NetworkPlayer NetPlayer;
    
    public TextMeshProUGUI gameTimer;
    public TextMeshProUGUI gameCountdown;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI ScoresUI;
    public TextMeshProUGUI TimesUI;
    public Transform BackButton;
    public Image backScore;
    public GameObject FinishZone;

    private int playerID;
    private bool[] playersState;
    private float[] playersTime;
    
    // Start is called before the first frame update
    void Start()
    {
        gameCountdown.text = "Prêt ?";
        player = GameObject.FindWithTag("MyPlayer");
        NetPlayer = player.GetComponent<NetworkPlayer>();
        playerID = NetPlayer.getID();
        playersState = new bool[] {false, false, false, false};
        playersTime = new float[4];
        playerName.text = "Player " + playerID;
        ScoresUI.text = "";
        TimesUI.text = "";
        BackButton.gameObject.SetActive(false);
        backScore.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        executionTime -= Time.deltaTime;
        
        if (executionTime < -1.5f && !running)
        {
            gameCountdown.text = "Terminé !\n" + time2str(playerTime);
            if (IsGameFinished())
            {
                displayScore();
                gameCountdown.text = "";
            }
            else
            {
                ScoresUI.text = "";
            }
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
        NetworkManager NetManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        NetManager.sendScore(playerID, playerTime);
    }

    private string time2str(float time)
    {
        int decPart = (int) -time;
        int floatPart = (int)(-time * 100f) % 100;

        return decPart + ":" + floatPart;
    }
    
    public void PlayerFinished(int id, float time)
    {
        playersState[id - 1] = true;
        playersTime[id - 1] = time;
    }

    public bool IsGameFinished()
    {
        bool finished = true;
        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            finished = finished && playersState[i];
        }

        return finished;
    }

    public void displayScore()
    {
        //int[] playersRank = new int[] {0, 1, 2, 3};
        string texte = "";
        string times = "";
        /*
        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            for (int c = i; c < PhotonNetwork.playerList.Length; c++)
            {
                if (playersTime[c] > playersTime[i])
                {
                    int a = playersRank[c];
                    float b = playersTime[c];
                    playersRank[c] = playersRank[i];
                    playersTime[c] = playersTime[i];
                    playersRank[i] = a;
                    playersTime[i] = b;
                }
            }
        }*/
        
        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            texte = texte + "Player " + (i+1) + "\n";
            times = times + time2str(playersTime[i]) + "\n";
        }
        
        TimesUI.text = times;
        ScoresUI.text = texte;
        BackButton.gameObject.SetActive(true);
        backScore.gameObject.SetActive(true);
    }
}
