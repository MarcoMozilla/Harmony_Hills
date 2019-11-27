using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snow_balls_ui : MonoBehaviour
{
    public List<GameObject> snow_ball_uis;


    public GameObject obj0;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    public GameObject obj7;
    public GameObject obj8;
    public GameObject obj9;
    public GameObject obj10;

    // Start is called before the first frame update
    void Start()
    {

        snow_ball_uis = new List<GameObject>(); 

        snow_ball_uis.Add(obj0);
        snow_ball_uis.Add(obj1);
        snow_ball_uis.Add(obj2);
        snow_ball_uis.Add(obj3);
        snow_ball_uis.Add(obj4);
        snow_ball_uis.Add(obj5);
        snow_ball_uis.Add(obj6);
        snow_ball_uis.Add(obj7);
        snow_ball_uis.Add(obj8);
        snow_ball_uis.Add(obj9);
        snow_ball_uis.Add(obj10);


        for (int i = 0; i < 11; i++) {
            if (i != 0){
                snow_ball_uis.ElementAt(i).SetActive(false);
            }
        }
    }

    // Update is called once per frame
    public static void hit(int index)
    {
        //Debug.Log("snow_ball_uis");
        //Debug.Log(snow_ball_uis.Length);
        //int index = Character.score % 10;
        //Debug.Log(index);
        // for (int i = 0; i < 10; i++) {
        //     if (i != index){
        //         snow_ball_uiss[i].SetActive(false);
        //     }
        // }

        GameObject obj = GameObject.Find("snowballs");
        Snow_balls_ui sbui = obj.GetComponent<Snow_balls_ui>();





        for (int i = 0; i < 11; i++) {
            if (i != index){
                sbui.snow_ball_uis.ElementAt(i).SetActive(false);
            }
        }
        sbui.snow_ball_uis.ElementAt(index).SetActive(true);
    }
}
