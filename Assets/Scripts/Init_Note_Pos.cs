using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_Note_Pos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] ways = GameObject.FindGameObjectsWithTag("way");
        int[] poses = { 0, 0, 1, 1, -1, -1, -1, -1, -1, 1, 1, -1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, -1, 0, 1, 1, -1, 0, -1, 0, 1, 1, 1, 1, 1, -1 };

        for (int i = 0; i < ways.Length; i++) {
            Transform t = ways[i].transform.GetChild(2);
            t.localPosition = new Vector3(poses[i], t.localPosition.y, t.localPosition.z);
            //Debug.Log(i.ToString() + ":"+ t.position);
        }

    }

   
}
