using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowText : MonoBehaviour
{

    public GameObject timeUp;
    public GameObject win;
    public GameObject lose;

    public TMP_Text timer;

    public GameObject[] pcs;
    public GameObject bus;
    public GameObject woman;

    // Start is called before the first frame update
    void Start()
    {
        End();
    }

    // Update is called once per frame
    void Update()
    {
        pcs = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < pcs.Length; i++)
        {
            GameObject pc = pcs[i];
            if (pc.GetComponent<PlayerController>().hasFinished == 1 && win != null && lose != null)
            {
                End();
                if (pc.name == "Player (Local)")
                    win.SetActive(true);
                else
                    lose.SetActive(true);
                return;
            } 
        }


        if (timer != null && timer.text == "Time is over!" && !(win.active || lose.active))
        {
            timeUp.SetActive(true);
            End();
            bus.GetComponent<Move>().enabled = true;
            woman.SetActive(false);
            return;
        }

    }

    public void End()
    {


        for (int i = 0; i < pcs.Length; i++)
        {

            GameObject pc = pcs[i];
            pc.GetComponent<PlayerController>().movementSpeed = 0;
        }
    }
}
