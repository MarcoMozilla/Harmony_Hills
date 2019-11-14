using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private Character char_scpt;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Character");
        char_scpt = obj.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        //46 59 47
        // time_leak = Character.time_leak;
    }
}
