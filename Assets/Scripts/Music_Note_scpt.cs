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

    public GameObject myPrefab;

    private void Awake()
    {
        //Debug.Log("Awake");
    }

    private void Start()
    {
        //Debug.Log("Start");
        //MusicSource.clip = MusicClip;
        //Debug.Log(this.gameObject);
        //Debug.Log(this.transform.Find("model3D"));
        
        //Debug.Log(this.transform.Find("model3D").Find("texts"));
        //Debug.Log(this.transform.Find("model3D").Find("texts").Find("text"));
        //Debug.Log(this.transform.Find("model3D").Find("texts").Find("text").GetComponent<TMP_Text>());
        
        tone_text = this.transform.Find("model3D").Find("texts").Find("text").GetComponent<TMP_Text>();
   
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
            //Debug.Log("HIT"+this.idx);
            MusicSource.Play();
            Destroy(transform.Find("model3D").gameObject);
            has_played = true;

            //Debug.Log("turn on light:" + this.idx.ToString());
            List<GameObject> lights = Lamp_Light_scpt.getlights(this.idx);

            foreach (GameObject light in lights)
            {
                flare_scpt fscpt = myPrefab.gameObject.GetComponent<flare_scpt>();
                fscpt.beginpos = this.transform.position;
                fscpt.endpos = light.transform.position;
                fscpt.light_idx = this.idx;

                GameObject flare = Instantiate(myPrefab, fscpt.beginpos, Quaternion.identity);

            }

           
            
            //Lamp_Light_scpt.turn_on_lights(this.idx);

        }
    }
}
