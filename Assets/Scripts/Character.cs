using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using TMPro;
using System;
public class Character : MonoBehaviour
{
    //public PathCreator pathCreatorLeft;
    //public PathCreator pathCreatorMiddle;
    //public PathCreator pathCreatorRight;
    //public PathCreator pathCreatorSelected;
    public int position = 0;
    float distanceTravelled;
    private TMP_Text tone_text;
    public int tone = 0;
    public int score = 0;
    public bool AxisActive = false;

    // smooth shift 
    public float move_period;
    private float hori_pos;
    private int curpos;
    private int nextpos;
    private float start_shift_time;

    public Vector2 idx_hidx;
    void Start()
    {
        //pathCreatorSelected = pathCreatorMiddle;
        position = 0;
        tone_text = transform.Find("mark").Find("Text (TMP)").GetComponent<TMP_Text>();
        idx_hidx = new Vector2(0, 0);
        
        hori_pos = 0;
        curpos = 0;
        nextpos = 0;
        

    }
    // Update is called once per frame
    void Update()
    {
        idx_hidx[0] = (float) Time.time / 2;
        idx_hidx[1] = hori_pos;
        int idx = Path_Node_scpt.idx_float2int(idx_hidx[0]);
        int hidx = Path_Node_scpt.hidx_float2int(idx_hidx[1]);
        this.transform.position = Path_Node_scpt.queryPos(idx_hidx, idx, hidx);
        this.transform.rotation = Path_Node_scpt.queryRotY(idx_hidx, idx, hidx);


        if (curpos != nextpos) {

            float time_length = Time.time - start_shift_time;
            float a = time_length / move_period;
            if (a >= 1) {
                curpos = nextpos;
                hori_pos = nextpos;
            }
            else {
                hori_pos = (1-a) * curpos + a * nextpos;

            }

        }
        else if (Input.GetKeyDown("left"))
        {
            
            if (nextpos - 1 >= -1)
            {
                nextpos = nextpos - 1;
                start_shift_time = Time.time;
            }
        }
        //if (Input.GetKeyDown(KeyCode.JoystickButton8) || Input.GetKeyDown("right"))
        if (Input.GetKeyDown("right") )
        {
            if (nextpos + 1 <= 1)
            {
                nextpos = nextpos + 1;
                start_shift_time = Time.time;
            }
         
        }


        /*
        if (Input.inputString != "") Debug.Log(Input.inputString);



        float speed = 20;
        distanceTravelled += speed * Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown("left"))
        if (AxisActive == false && ((Input.GetAxis("DPadX") == -1f) || Input.GetKeyDown("left")))
        {
            AxisActive = true;
            if (position == 2)
            {
                pathCreatorSelected = pathCreatorMiddle;
                position = 0;
            } else if (position == 0)
            {
                pathCreatorSelected = pathCreatorLeft;
                position = -2;
            }
        }
        //if (Input.GetKeyDown(KeyCode.JoystickButton8) ||Input.GetKeyDown("right"))
        if (AxisActive == false && ((Input.GetAxis("DPadX") == 1f)|| Input.GetKeyDown("right")))
        {
            AxisActive = true;
            if(position == -2)
            {
                pathCreatorSelected = pathCreatorMiddle;
                position = 0;
            } else if (position == 0)
            {
                pathCreatorSelected = pathCreatorRight;
                position = 2;
            }
        }

        if (Input.GetAxis("DPadX") == 0f)
        {
            AxisActive = false;
        }
        
        transform.position = pathCreatorSelected.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreatorSelected.path.GetRotationAtDistance(distanceTravelled);
    */
        if (Input.GetKeyDown(KeyCode.UpArrow) && tone < 2)
        {
            tone += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && tone > -2)
        {
            tone -= 1;
        }
        if (tone == 0)
        { 
            tone_text.text = "";
        }
        else if (tone > 0)
        {
            tone_text.text = new String('+', tone);
        }
        else if (tone < 0) {
            tone_text.text = new String('-', -tone);
        }
    }


    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "music_note")
        {
            score += 50;

            Music_Note_scpt mns = other.gameObject.GetComponent<Music_Note_scpt>();
            mns.hit();


        }
        else if (other.tag == "ice_fall")
        {

            //撞到ice的
        }
        else if (other.tag == "gap_enter") {

            //进入gap
        }

    }
    

}
