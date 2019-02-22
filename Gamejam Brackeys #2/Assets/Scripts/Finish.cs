using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Finish : NetworkBehaviour
{
    public int won = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        if (!isServer)
            return;


    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Finish"))
        {
            won = 1;
            RpcSyncVars(won);
        }
    }

    [ClientRpc]
    void RpcSyncVars(int varToSync)
    {
        won = varToSync;
    }
}
