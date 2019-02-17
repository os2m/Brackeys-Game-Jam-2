using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{

    public Text maxPlayerCount;
    public Text adressFieldText;

    private int port;
    private string ip;


    // Start is called before the first frame update
    void Start()
    {
        maxPlayerCount.text = singleton.maxConnections + " Slots";

        string[] adress = adressFieldText.text.Split(':');
        if (adress.Length >= 1)
            ip = adress[0];
        if (adress.Length >= 2)
        port = int.Parse(adress[1]);
    }

    public void Host()
    {
        singleton.networkPort = port;
        singleton.StartHost();
    }

    public void Join()
    {
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
