using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snowballs_whole : MonoBehaviour
{
    public List<GameObject> whole_snow_ball_uis;
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
        whole_snow_ball_uis = new List<GameObject>(); ;

        whole_snow_ball_uis.Add(obj0);
        whole_snow_ball_uis.Add(obj1);
        whole_snow_ball_uis.Add(obj2);
        whole_snow_ball_uis.Add(obj3);
        whole_snow_ball_uis.Add(obj4);
        whole_snow_ball_uis.Add(obj5);
        whole_snow_ball_uis.Add(obj6);
        whole_snow_ball_uis.Add(obj7);
        whole_snow_ball_uis.Add(obj8);
        whole_snow_ball_uis.Add(obj9);
        whole_snow_ball_uis.Add(obj10);
        int score = Character.score;
        for (int i = 0; i < 11; i++) {
            whole_snow_ball_uis.ElementAt(i).SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int score = Character.score;
        GameObject obj = GameObject.Find("snowballs_whole");
        Snowballs_whole swbui = obj.GetComponent<Snowballs_whole>();
        int index = score / 10;
        for (int i = 0; i < 11; i++) {
            if (i >= index){
                swbui.whole_snow_ball_uis.ElementAt(i).SetActive(false);
            }else{
                swbui.whole_snow_ball_uis.ElementAt(i).SetActive(true);
            }
        }
    }
}
