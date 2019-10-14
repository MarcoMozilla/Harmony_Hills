using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern_scpt : MonoBehaviour
{
    // Start is called before the first frame update

    public int idx;
    void Awake()
    {

    Lamp_Light_scpt lls = this.transform.Find("mark").Find("entity_holder").Find("lamp_lights").Find("Sphere").GetComponent<Lamp_Light_scpt>();

        lls.idx = this.idx;
    

}

}
