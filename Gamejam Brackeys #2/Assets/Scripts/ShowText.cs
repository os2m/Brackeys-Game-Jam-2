using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowText : MonoBehaviour
{
    public GameObject wait;
    public GameObject timeUp;
    public GameObject win;
    public GameObject lose;

    public TMP_Text timer;
    public TMP_Text waitText;

    public GameObject[] pcs;
    public GameObject bus;
    public GameObject woman;

    private bool end;

    public float playerMovementSpeed = .05f;
    private float time = 10;

    private GameObject pc;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pcs = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < pcs.Length; i++)
        {
            pc = pcs[i];
            if (pc.GetComponent<Finish>().won == 1 && win != null && lose != null && !end)
            {
                end = true;
                End(0);

                if (pc.name == "Player (Local)")
                {
                    win.SetActive(true);
                    PlayerPrefs.SetInt("win", PlayerPrefs.GetInt("win") + 1);
                }

                else
                {
                    lose.SetActive(true);
                    PlayerPrefs.SetInt("lose", PlayerPrefs.GetInt("lose") + 1);
                }

                return;
            } 
        }

        if (timer != null && timer.text == "Wait!")
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                waitText.text = "Wait " + (int) time + " seconds for other players to log in.";

            }

            End(0);
            wait.SetActive(true);
        }

        else if (timer != null && timer.text == "Time is over!" && !end && !(win.active || lose.active))
        {
            end = true;
            timeUp.SetActive(true);
            End(0);
            bus.GetComponent<Move>().enabled = true;
            woman.SetActive(false);
            PlayerPrefs.SetInt("timeUp", PlayerPrefs.GetInt("timeUp") + 1);
            return;
        }
        else if (!end && !(win.active || lose.active))
        {
            End(playerMovementSpeed);
            wait.SetActive(false);
        }




    }

    public void End(float speed)
    {


        for (int i = 0; i < pcs.Length; i++)
        {

            GameObject pc = pcs[i];
            pc.GetComponent<PlayerController>().movementSpeed = speed;
        }
    }
}
