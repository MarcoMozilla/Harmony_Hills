using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_Light_scpt : MonoBehaviour
{
    // Start is called before the first frame update

    // private float startime;
    // private bool ison;
    private static Dictionary<int, List<GameObject>> dctn_idx_2_lights;
    public int idx = 0;
    void Start()
    {

        // startime = 0f;
        // ison = false;
    }

    // Update is called once per frame
    void Update()
    {

        // if (ison && Time.time - startime > 10) {
        //     this.turn_off();
        // }
       

    }

    public void turn_on()
    {

        // GameObject lobj = GameObject.Find("Directional Light");

        // direct_light_scpt lscpt = lobj.GetComponent<direct_light_scpt>();

        // Light lt = lobj.GetComponent<Light>();

        // lt.intensity = lscpt.addlight(); 

        this.transform.GetComponent<Light>().enabled = true;
        this.transform.GetComponent<LensFlare>().enabled = true;
        //Debug.Log(this.transform.GetComponent<LensFlare>().enabled = true);
        this.transform.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        // ison = true;
        // startime = Time.time;
    }

    public void turn_off()
    {

        transform.GetComponent<Light>().enabled = false;
        transform.GetComponent<LensFlare>().enabled = false;
        transform.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        // ison = false;
    }

    public static void init_dctn_idx_2_lights()
    {

        //Debug.Log("init light dictionary");
        Dictionary<int, List<GameObject>> res = new Dictionary<int, List<GameObject>>();

        GameObject[] lamp_lights = GameObject.FindGameObjectsWithTag("lamp_light");
        foreach (GameObject lamp_light in lamp_lights)
        {
            Lamp_Light_scpt lls = lamp_light.GetComponent<Lamp_Light_scpt>();

             
            //Debug.Log(lls.idx);
            if (res.ContainsKey(lls.idx))
            {
                res[lls.idx].Add(lamp_light);
            }
            else
            {
                List<GameObject> new_list = new List<GameObject>();
                new_list.Add(lamp_light);
                res.Add(lls.idx, new_list);
            }
        }
        dctn_idx_2_lights = res;
        //Debug.Log(dctn_idx_2_lights);

    }


    public static void turn_on_lights(int need_turn_on_idx)
    {
        if (!dctn_idx_2_lights.ContainsKey(need_turn_on_idx))
        {
            Debug.Log("invalid need_turn_on_idx");
        }

        
        List<GameObject> lights = dctn_idx_2_lights[need_turn_on_idx];
        foreach (GameObject light in lights)
        {
            Lamp_Light_scpt lls = light.GetComponent<Lamp_Light_scpt>();
            lls.turn_on();
        }
        
    }

    public static List<GameObject> getlights(int need_turn_on_idx)
    {
        if (!dctn_idx_2_lights.ContainsKey(need_turn_on_idx))
        {
            Debug.Log("invalid need_turn_on_idx");
        }


        List<GameObject> lights = dctn_idx_2_lights[need_turn_on_idx];
        return lights;

    }

}
