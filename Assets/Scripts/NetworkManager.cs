﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : Photon.PunBehaviour
{
    public Camera lobbyCam;
    public Transform[] spawnPoints = new Transform[4];
    public Text NetStatus;
    public string playerPrefabName = "Player";
    public GameObject NetManager;

    public const string Version = "1.101";
    public const string RoomName = "Multiplayer";

    private int playerID;
    private GameObject player;

    private GameObject playerUI;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(Version);
        playerID = PhotonNetwork.countOfPlayers;
        PhotonNetwork.automaticallySyncScene = true;
        DontDestroyOnLoad(NetManager);
    }

    void Update()
    {
        NetStatus.text = "Player" + playerID + ": " + PhotonNetwork.connectionStateDetailed.ToString();
        lobbyCam.enabled = true;
    }

    public override void OnConnectionFail(DisconnectCause cause)
    {
        print("Connection failed!" + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions() {IsVisible = false, MaxPlayers = 4};
        PhotonNetwork.JoinOrCreateRoom(RoomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        playerID = PhotonNetwork.playerList.Length;
        lobbyCam.enabled = true;
        DontDestroyOnLoad(lobbyCam);
        player = PhotonNetwork.Instantiate(playerPrefabName, spawnPoints[playerID - 1].position, spawnPoints[playerID - 1].rotation, 0);
        DontDestroyOnLoad(player);
        player.tag = "MyPlayer";
    }
    
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        print("New Player Connected");
    }
    
    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        print("Player DISconnected");
    }
    
    public void PreLoadLevel()
    {
        photonView.RPC("PrepareLevel", PhotonTargets.All, true);

        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.isMessageQueueRunning = false;
            new WaitForSeconds(1f);
            PhotonNetwork.LoadLevel("Test Multi");
        }
        PhotonNetwork.isMessageQueueRunning = true;
    }

    [PunRPC]
    void PrepareLevel(bool state)
    {
        NetworkPlayer NetPlayer = player.GetComponent<NetworkPlayer>();
        NetPlayer.setStatus(state, playerID);
        
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var otherplayer in players)
        {
            DontDestroyOnLoad(otherplayer);
        }
    }
}