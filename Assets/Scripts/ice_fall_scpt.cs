using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice_fall_scpt : MonoBehaviour
{
    // Start is called before the first frame update


    public float fall_time;

    void Start()
    {
        Physics.gravity = new Vector3(0, -200.0F, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - Character.start_time) > fall_time) {
            Rigidbody rb = this.transform.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
        
    }
}
