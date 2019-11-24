using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private Character char_scpt;
    // Start is called before the first frame update

    public AudioClip ac;
    public AudioSource asrc;
    void Start()
    {
        GameObject obj = GameObject.Find("Character");
        char_scpt = obj.GetComponent<Character>();
        asrc = this.GetComponent<AudioSource>();

        ac = asrc.clip;
    }

    // Update is called once per frame
    void Update()
    {
        //46 59 47
        // time_leak = Character.time_leak;
    }


    
}
