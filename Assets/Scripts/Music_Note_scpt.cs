using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Music_Note_scpt: MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public int tone = 0;
    public int idx = 0;
    private TMP_Text tone_text;
    private bool has_played = false;



    private void Awake()
    {
        //Debug.Log("Awake");
    }

    private void Start()
    {
        //Debug.Log("Start");
        MusicSource.clip = MusicClip;
        //Debug.Log(transform.Find("texts"));
        //Debug.Log(transform.Find("texts").Find("text").GetComponent<TMP_Text>());
        tone_text = transform.Find("model3D").Find("texts").Find("text").GetComponent<TMP_Text>();
        if (tone == 0)
        { 
        }
        else if (tone > 0)
        {
            tone_text.text = new String('+', tone);
        }
        else if (tone < 0) {
            tone_text.text = new String('-', -tone);
        }
    }


    private void Update()
    {

    }
    public void hit()
    {
        if (!has_played) {
            MusicSource.Play();
            Destroy(transform.Find("model3D").gameObject);
            has_played = true;
            Lamp_Light_scpt.turn_on_lights(this.idx);
            Debug.Log("turn on light:" + this.idx.ToString());
        }
    }
}
