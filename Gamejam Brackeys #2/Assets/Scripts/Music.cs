using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    private AudioSource music;
    public Button button;
    private float maxVolume = 0.3f;

    public Sprite on;
    public Sprite off;


    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        button = GameObject.Find("MusicButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMusic()
    {
        if (music.volume == 0)
        {
            music.volume = maxVolume;
            if (button != null)
                button.image.sprite = on;
        }
        else
        {
            music.volume = 0;
            if (button != null)
                button.image.sprite = off;
        }
    }
}
