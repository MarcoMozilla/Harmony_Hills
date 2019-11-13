using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direct_light_scpt : MonoBehaviour
{
    // Start is called before the first frame update

    public float deduction;
    public float adder;
    public float lo;
    public float hi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Light t = this.GetComponent<Light>();

        t.intensity = this.sublight();
    }


    float sublight() {
        Light t = this.GetComponent<Light>();

        float value = t.intensity;

        if (value > lo) {
             value -= deduction;
        }
        return value;
    }

    public float addlight() {
        Light t = this.GetComponent<Light>();

        float value = t.intensity;
        if (value < hi) {
            value += adder;
        }

        return value;
    }
}
