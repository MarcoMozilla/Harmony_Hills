using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow_balls_ui : MonoBehaviour
{
    public static GameObject[] snow_ball_uis;
    
    // Start is called before the first frame update
    void Start()
    {
        snow_ball_uis = GameObject.FindGameObjectsWithTag("snow_ball_ui");
        for (int i = 0; i < 11; i++) {
            if (i != 0){
                snow_ball_uis[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    public static void hit(int index)
    {
        Debug.Log("snow_ball_uis");
        Debug.Log(snow_ball_uis.Length);
        //int index = Character.score % 10;
        //Debug.Log(index);
        // for (int i = 0; i < 10; i++) {
        //     if (i != index){
        //         snow_ball_uiss[i].SetActive(false);
        //     }
        // }
        for (int i = 0; i < 11; i++) {
            if (i != index){
                snow_ball_uis[i].SetActive(false);
            }
        }
        snow_ball_uis[index].SetActive(true);
    }
}
