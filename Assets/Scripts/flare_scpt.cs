using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flare_scpt : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 beginpos;
    public Vector3 endpos;
    public float duration;

    public float begintime;
    public float curtime;

    public int light_idx;
    void Start()
    {
        begintime = Time.time;
        curtime = Time.time;
        this.transform.position = beginpos;
        //Debug.Log("initialzie flare");
    }

    // Update is called once per frame
    void Update()
    {

        curtime = Time.time - begintime;
        float a = curtime / duration;


        if (a > 1)
        {
            a = 1;
            Lamp_Light_scpt.turn_on_lights(light_idx);


        }

        
            
            this.transform.position = (1 - a) * beginpos + a * endpos;
            //Debug.Log(this.transform.position);
        
    }
}
