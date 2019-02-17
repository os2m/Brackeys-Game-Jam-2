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
    public TMP_Text adressFieldText;

    private int port;
    private string ip;


    // Start is called before the first frame update
    void Start()
    {
        if (maxPlayerCount != null)
            maxPlayerCount.text = singleton.maxConnections + " Slots";
        adressFieldText.text = "localhost:7777";
    }

    public void ReadInputField()
    {
        string[] adress = adressFieldText.text.Split(':');
            ip = adress[0];
        if (adress.Length >= 2)
            port = int.Parse(adress[1]);
        else
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
            ReadInputField();
            Debug.Log("Join on: " + ip + ":" + port);
            singleton.networkAddress = ip;
            singleton.networkPort = port;
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
}
