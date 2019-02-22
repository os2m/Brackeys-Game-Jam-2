using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowStatistics : MonoBehaviour
{
    public TMP_Text win;
    public TMP_Text lose;
    public TMP_Text timeUp;

    void Update()
    {
        win.text = "Dream woman reached: " + PlayerPrefs.GetInt("win");
        lose.text = "Dream woman got another man: " + PlayerPrefs.GetInt("lose");
        timeUp.text = "Dream woman has left: " + PlayerPrefs.GetInt("timeUp");
    }
}
