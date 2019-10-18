using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class tester : MonoBehaviour
{
    // Start is called before the first frame update



    public Vector2 idx_hidx;

    Vector2 adder ;

    private void Start()
    {
        adder = new Vector2(0, 1);
    }

    void Update()
    {


        
        float speed = (float)0.01;
        float eps = (float)0.00001;
        


        //Debug.Log("pos:"+idx_hidx);
        if (idx_hidx[0] > 1 ) {
            //Debug.Log("up");
            adder = new Vector2(0, 1);
            idx_hidx = new Vector2(1, -1);
        }
        else if (idx_hidx[0] < 0) {
            //Debug.Log("down");
            adder = new Vector2(0, -1);
            idx_hidx = new Vector2(0, 1);
        }
        if (idx_hidx[1] > 1)
        {
            //Debug.Log("right");
            adder = new Vector2(-1, 0);
            idx_hidx = new Vector2(1, 1);
        }
        else if (idx_hidx[1] < -1)
        {
            Debug.Log("left");
            adder = new Vector2(1, 0);

            idx_hidx = new Vector2(0,-1);
        }

        //Debug.Log(adder);
        idx_hidx = idx_hidx + adder * speed; 
        

        
        int idx = Path_Node_scpt.idx_float2int(idx_hidx[0]);
        int hidx = Path_Node_scpt.hidx_float2int(idx_hidx[1]);
        this.transform.position = Path_Node_scpt.queryPos(idx_hidx, idx, hidx);
        this.transform.rotation  = Path_Node_scpt.queryRotY(idx_hidx, idx, hidx);



        //Debug.Log(this.transform.up);
    }

    // Update is called once per frame

}
