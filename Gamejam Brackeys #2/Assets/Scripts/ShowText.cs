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

    // Start is called before the first frame update
    void Start()
    {
        End();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != null && timer.text == "Time is over!")
        {
            timeUp.SetActive(true);
            End();
            return;
        }

    }

    public void End()
    {
        pcs = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < pcs.Length; i++)
        {
            Debug.Log(pcs);
            GameObject pc = pcs[i];
            pc.GetComponent<PlayerController>().movementSpeed = 0;
        }
    }
}
