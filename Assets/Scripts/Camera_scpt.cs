using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_scpt : MonoBehaviour
{
    // Start is called before the first frame update

    private Character char_scpt;
    void Start()
    {
        GameObject obj = GameObject.Find("Character");
        char_scpt = obj.GetComponent<Character>();
        Debug.Log(obj);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector2 logipos = new Vector2(0, 0);
        logipos[0] = char_scpt.idx_hidx[0]; 
        int idx = Path_Node_scpt.idx_float2int(logipos[0]);
        int hidx = Path_Node_scpt.hidx_float2int(logipos[1]);
        //Debug.Log(idx_hidx);
        Vector3 pos = Path_Node_scpt.queryPos(logipos, idx, hidx);

        this.transform.position = pos;
        this.transform.rotation = Path_Node_scpt.queryRotY(logipos, idx, hidx);

    }
}
