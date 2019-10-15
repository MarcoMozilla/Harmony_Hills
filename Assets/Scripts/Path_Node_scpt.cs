using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Path_Node_scpt : MonoBehaviour
{
    // Start is called before the first frame update

    public int idx;
    public static Dictionary<int, GameObject> dctn_idx_2_mark_set;
    void Start()
    {

    }

    void Update()
    {

    }


    /*
        hidx = -1:left
        hidx = 1 : right
        hidx = 0 : mid
    */
    public static Vector2 getLogiPos(int idx,int hidx)
    { 
        Vector2 res = new Vector2(idx, hidx);
        return res;
    }
    public static Vector3 getRealPos(int idx,int hidx)
    {
        Vector3 res = new Vector3(-1, -1, -1);

        //Debug.Log("get real pos:" + idx + "," + hidx);
        GameObject curobj = dctn_idx_2_mark_set[idx];
        if (hidx == 0) {res = curobj.transform.Find("mid").position; }
        else if (hidx == -1){res = curobj.transform.Find("left").position; }
        else if (hidx == 1){ res =  curobj.transform.Find("right").position;}
        else{Debug.Log("getRealPos: invalid idx");}
        //Debug.Log("get real pos return:" + res);
        return res;
    }

    public static Vector3 getNormal(int idx,int hidx)
    {

        Vector3 res = new Vector3(-1, -1, -1);
        GameObject curobj = dctn_idx_2_mark_set[idx];
        if (hidx == 0) { res = curobj.transform.Find("mid").up; }
        else if (hidx == -1) { res = curobj.transform.Find("left").up; }
        else if (hidx == 1) { res = curobj.transform.Find("right").up; }
        else { Debug.Log("getNormal: invalid idx"); }
        return res;

    }


    public static Vector2[] get4LogiPos(int idx, int hidx)
    {
        /*
         * corner order
         * 32   23
         * 10   01
         */
        Vector2[] res = new Vector2[4];
        if (notLast(idx))
        {
            res[0] = Path_Node_scpt.getLogiPos(idx, 0);
            res[1] = Path_Node_scpt.getLogiPos(idx, hidx);
            res[2] = Path_Node_scpt.getLogiPos(idx + 1, 0);
            res[3] = Path_Node_scpt.getLogiPos(idx + 1, hidx);
        }
        return res;


    }

    public static Vector3[] get4RealPos(int idx, int hidx)
    {
        /*
         * corner order
         * 32   23
         * 10   01
         */
        //Debug.Log("get4RealPos("+idx+","+hidx+")");
        Vector3[] res = new Vector3[4];
        if (notLast(idx))
        {
            res[0] = Path_Node_scpt.getRealPos(idx,0);
            res[1] = Path_Node_scpt.getRealPos(idx,hidx);
            res[2] = Path_Node_scpt.getRealPos(idx+1,0);
            res[3] = Path_Node_scpt.getRealPos(idx+1,hidx);
        }

        //Debug.Log(res[0]);
        //Debug.Log(res[1]);
        //Debug.Log(res[2]);
        //Debug.Log(res[3]);
        return res;
    }

    public static Vector3[] get4Normal(int idx, int hidx)
    {
        /*
         * corner order
         * 32   23
         * 10   01
         */
        Vector3[] res = new Vector3[4];
        if (notLast(idx))
        {
            res[0] = Path_Node_scpt.getNormal(idx, 0);
            res[1] = Path_Node_scpt.getNormal(idx, hidx);
            res[2] = Path_Node_scpt.getNormal(idx + 1, 0);
            res[3] = Path_Node_scpt.getNormal(idx + 1, hidx);
        }



        return res;

    }

   

    public static float[] get4weight(Vector2 querylogiPos, int idx, int hidx)
    {

        float[] weight4 = new float[4];
        Vector2[] logiPos4 = get4LogiPos(idx, hidx);

        // Debug.Log(logiPos4[0]);
        // Debug.Log(logiPos4[1]);
        //Debug.Log(logiPos4[2]);
        // Debug.Log(logiPos4[3]);

        // Debug.Log("query logic:" + querylogiPos);



        // query v h : x, y
        if (querylogiPos[1] >= 0)
        {
            //right
            //  Debug.Log("right");


            if (querylogiPos[1] + idx >= querylogiPos[0])
            {
                //down
                // Debug.Log("down");
                float[] weight3 = getweight3(querylogiPos, logiPos4[0], logiPos4[1], logiPos4[3]);

                weight4[0] = weight3[0];
                weight4[1] = weight3[1];
                weight4[2] = 0;
                weight4[3] = weight3[2];

            }
            else
            {
                //up

                //Debug.Log("up");
                float[] weight3 = getweight3(querylogiPos, logiPos4[0], logiPos4[2], logiPos4[3]);

                weight4[0] = weight3[0];
                weight4[1] = 0;
                weight4[2] = weight3[1];
                weight4[3] = weight3[2];

            }

        }
        else
        {
            //left
            //Debug.Log("left");
            if (-querylogiPos[1] + idx >= querylogiPos[0])
            {
                //Debug.Log("down");
                //down

                float[] weight3 = getweight3(querylogiPos, logiPos4[0], logiPos4[1], logiPos4[3]);

                weight4[0] = weight3[0];
                weight4[1] = weight3[1];
                weight4[2] = 0;
                weight4[3] = weight3[2];


            }
            else
            {
                //up
                //Debug.Log("up");
                float[] weight3 = getweight3(querylogiPos, logiPos4[0], logiPos4[2], logiPos4[3]);

                weight4[0] = weight3[0];
                weight4[1] = 0;
                weight4[2] = weight3[1];
                weight4[3] = weight3[2];

            }
        }



        //Debug.Log(weight4[0]);
        //Debug.Log(weight4[1]);
        //Debug.Log(weight4[2]);
        //Debug.Log(weight4[3]);
        return weight4;
    }


 
    public static Vector3 queryPos(Vector2 querylogiPos, int idx, int hidx)
    {

        float[] weight4 = get4weight(querylogiPos, idx, hidx);
        Vector3[] realPos4 = get4RealPos(idx, hidx);
        Vector3 resRealPos = new Vector3(0, 0, 0);
        for (int i = 0; i < 4; i++)
        {
            resRealPos += weight4[i] * realPos4[i];
        }
        return resRealPos;


    }

    public static Vector3 queryNormal(Vector2 querylogiPos, int idx, int hidx)
    {
        float[] weight4 = get4weight(querylogiPos, idx, hidx);
        Vector3[] normal4 = get4Normal(idx, hidx);
        Vector3 resNormal = new Vector3(0, 0, 0);
        for (int i = 0; i < 4; i++)
        {
            resNormal += weight4[i] * normal4[i];
        }
        return resNormal;
    }





    public static Quaternion getRotY(int idx, int hidx)
    {

        Quaternion res = Quaternion.identity;
        GameObject curobj = dctn_idx_2_mark_set[idx];
        if (hidx == 0) { res = curobj.transform.Find("mid").rotation; }
        else if (hidx == -1) { res = curobj.transform.Find("left").rotation; }
        else if (hidx == 1) { res = curobj.transform.Find("right").rotation; }
        else { Debug.Log("getNormal: invalid idx"); }
        return res;

    }
    public static Quaternion[] get4RotY(int idx, int hidx)
    {
        /*
         * corner order
         * 32   23
         * 10   01
         */
        Quaternion[] res = new Quaternion[4];
        if (notLast(idx))
        {
            res[0] = Path_Node_scpt.getRotY(idx, 0);
            res[1] = Path_Node_scpt.getRotY(idx, hidx);
            res[2] = Path_Node_scpt.getRotY(idx + 1, 0);
            res[3] = Path_Node_scpt.getRotY(idx + 1, hidx);
        }



        return res;

    }
    public static Quaternion queryRotY(Vector2 querylogiPos, int idx, int hidx)
    {
        float[] weight4 = get4weight(querylogiPos, idx, hidx);
        Quaternion[] y4 = get4RotY(idx, hidx);
        
        

        float x =  (weight4[0] * y4[0].x + weight4[1] * y4[1].x + weight4[2] * y4[2].x + weight4[3] * y4[3].x)/(weight4[0]+weight4[1]+weight4[2]+weight4[3]);
        float y = (weight4[0] * y4[0].y + weight4[1] * y4[1].y + weight4[2] * y4[2].y + weight4[3] * y4[3].y) / (weight4[0] + weight4[1] + weight4[2] + weight4[3]);
        float z = (weight4[0] * y4[0].z + weight4[1] * y4[1].z + weight4[2] * y4[2].z + weight4[3] * y4[3].z) / (weight4[0] + weight4[1] + weight4[2] + weight4[3]);
        float w = (weight4[0] * y4[0].w + weight4[1] * y4[1].w + weight4[2] * y4[2].w + weight4[3] * y4[3].w) / (weight4[0] + weight4[1] + weight4[2] + weight4[3]);

        Quaternion resY = new Quaternion(x,y,z,w);
        return resY;
    }

    
    public static bool notLast(int idx)
    {
        //Debug.Log(idx);
        return Path_Node_scpt.dctn_idx_2_mark_set.ContainsKey(idx+1);
    }


    public static void init_dctn_idx_2_mark_set()
    {

        //Debug.Log("init path node dictionary");
        Dictionary<int, GameObject> res = new Dictionary<int, GameObject>();

        GameObject[] mark_sets = GameObject.FindGameObjectsWithTag("mark_set");
        foreach (GameObject mark_set in mark_sets)
        {
            Path_Node_scpt mss = mark_set.GetComponent<Path_Node_scpt>();


            //Debug.Log(lls.idx);
            if (res.ContainsKey(mss.idx))
            {
                res[mss.idx] = mark_set;
            }
            else
            {

                res.Add(mss.idx, mark_set);
            }
        }
        Path_Node_scpt.dctn_idx_2_mark_set = res;
        //Debug.Log("finish init");

    }


    public static int idx_float2int(float idx) {

        if (idx < 0) {
            return 0;
        }
        return (int)Math.Floor(idx);
    }

    public static int hidx_float2int(float hidx)
    {
        if (hidx >= 0)
        {
            return 1;
        }
        else {
            return -1;
        }

        Debug.Log("hidx_float2int Error");
    }


    public static float[] getweight3(Vector2 q, Vector2 a, Vector2 b, Vector2 c) {

        float[] res = new float[3];


       // Debug.Log("a" + a);
       // Debug.Log("b" + b);
       // Debug.Log("c" + c);
       // Debug.Log("q" + q);

        Vector2 qa = (a- q);
        Vector2 qb = (b-q);
        Vector2 qc = (c-q);

       // Debug.Log("qa" + qa);
      //  Debug.Log("qb" + qb);
      //  Debug.Log("qc" + qc);

        Vector3 qa3 = new Vector3(qa[0],0,qa[1]);
        Vector3 qb3 = new Vector3(qb[0], 0, qb[1]);
        Vector3 qc3 = new Vector3(qc[0], 0, qc[1]);

      //  Debug.Log("qa3" + qa3);
      //  Debug.Log("qb3" + qb3);
      //  Debug.Log("qc3" + qc3);

        float qab = Vector3.Cross(qa3,qb3).magnitude;
        float qbc = Vector3.Cross(qb3, qc3).magnitude;
        float qca = Vector3.Cross(qc3, qa3).magnitude;

       // Debug.Log("qab" + qab);
       // Debug.Log("qbc" + qbc);
       // Debug.Log("qca" + qca);
      //  Debug.Log("ab:"+qab);
       // Debug.Log("bc:"+qbc);
       // Debug.Log("ca"+qca);
        float sum = qab + qbc + qca;

        res[0] = qbc / sum;
        res[1] = qca / sum;
        res[2] = qab / sum;


        return res;
    }

}



