using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Timer : NetworkBehaviour
{
    [SyncVar] public float time = 0;
    [SyncVar] public int isMaster = 0;

    TMP_Text text;

    // Start is called before the first frame update
    private void Start()
    {

        if (isServer)
        {
            time = 60;
            if (isLocalPlayer)
                isMaster = 1;
        }
            text = GameObject.Find("Timer").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            if (time > 0)
                time -= Time.deltaTime;

            RpcSyncVars(time, isMaster);
        }


        if (isMaster == 1 && text != null)
        {
            if (time > 50)
                text.text = "Wait!";
            else if (time <= 50 && time > 0)
                text.text = (int)time + "";
            else
                text.text = "Time is over!";
        }
    }

    [ClientRpc]
    void RpcSyncVars(float varToSync, int master)
    {
        time = varToSync;
        isMaster = master;
    }
}

