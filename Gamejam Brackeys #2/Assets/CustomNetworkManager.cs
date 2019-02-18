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


    // Start is called before the first frame update
    void Start()
    {
        if (maxPlayerCount != null)
            maxPlayerCount.text = singleton.maxConnections + " Slots";
        //adressFieldText.text = "25.90.252.115";
    }

    public void ReadInputField()
    {
        //string[] adress = adressFieldText.text.Split(':');
            ip = adressFieldText.text;
        //if (adress.Length >= 2)
            //port = int.Parse(adress[1]);
        //else
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
        adressFieldText.text = "Marc";
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

    public void Update()
    {
        Debug.Log(adressFieldText.text.ToString() == "25.90.252.115");
        //Debug.Log(adressFieldText.text + "" == "Marc");
        //Debug.Log(adressFieldText.GetParsedText() == "Marc");
    }
}
