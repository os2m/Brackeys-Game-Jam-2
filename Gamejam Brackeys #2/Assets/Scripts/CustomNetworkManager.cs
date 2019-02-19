using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System;

public class CustomNetworkManager : NetworkManager
{

    public Text maxPlayerCount;
    public Text adressFieldText;

    private int port;
    private string ip;

    public GameObject offlineMenu;
    public GameObject onlineMenu;


    // Start is called before the first frame update
    void Start()
    {
        if (maxPlayerCount != null)
            maxPlayerCount.text = singleton.maxConnections + " Slots";
    }

    public void ReadInputField()
    {
            ip = adressFieldText.text;
            port = 7777;
    }

    public void Host()
    {
        ReadInputField();
        Debug.Log("Host on port: " + port);
        singleton.networkPort = port;
        singleton.StartHost();
    }

    public void Join()
    {
        //ReadInputField();
        Debug.Log("Join on: " + adressFieldText.text + ":" + 7777);
            singleton.networkAddress = adressFieldText.text;
            singleton.networkPort = 7777;
            singleton.StartClient();
    }

    public void Disconnect()
    {
        singleton.StopHost();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void AddMaxConnections(int playerCount)
    {
        if (singleton.maxConnections > 0 || playerCount == 1)
            singleton.maxConnections += playerCount;
        maxPlayerCount.text = singleton.maxConnections + " Slots";
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            offlineMenu.SetActive(true);
            onlineMenu.SetActive(false);
        }
        else
        {
            offlineMenu.SetActive(false);
            onlineMenu.SetActive(true);
        }
    }
}
