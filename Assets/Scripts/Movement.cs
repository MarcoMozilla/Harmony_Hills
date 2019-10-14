using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Text.RegularExpressions;
public class Movement : MonoBehaviour
{

    public static int score = 0;
    public static int max_score = 0;
    float speed = 0.40f;

    public int p = 0;

    public static Text st;
    public static Text mst;


    
    public float restartDelay = 1f;

    public float endDelay = 1f;



    private void Start()
    {
        //在整个游戏中只会运行一次的代码放在这里
        Lamp_Light_scpt.init_dctn_idx_2_lights();
    }

    /*
    public void Start()
    {
        st = GameObject.Find("score_text").GetComponent<Text>();
        mst= GameObject.Find("max_score_text").GetComponent<Text>();
       

        Physics.gravity = new Vector3(0, -1000.0F, 0);

        if (File.Exists("info.txt"))
        {
            string s  = File.ReadAllText("info.txt");
            mst.text = "Max Score: " + s;
            string resultString = Regex.Match(s, @"\d+").Value;
            max_score = Int32.Parse(resultString);
        }
        else {
            mst.text = "Max Score:0";
        }
        score = 0;
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.JoystickButton7) && p != -2)
        {
            p += -2;
            transform.position = transform.position + transform.right * -2;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton8) && p != 2)
        {
            p += 2;
            transform.position = transform.position + transform.right * 2;
        }

        if (Input.GetKeyDown("left") && p != -2)
        {
            p += -2;
            transform.position = transform.position + transform.right * -2;

        }
        else if (Input.GetKeyDown("right") && p != 2)
        {
            p += 2;
            transform.position = transform.position + transform.right * 2;
        }


    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
   
       transform.position += transform.forward * speed;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "music_note") {
            score += 50;
            st.text = "Score: " + score.ToString();
            if (score >= max_score)
            {
                max_score = score;
                mst.text = "Max Score: " + max_score.ToString();
            }





            Transform top1 = other.transform.parent.gameObject.transform.GetChild(0).GetChild(0);

            Transform top2 = other.transform.parent.gameObject.transform.GetChild(1).GetChild(0);
           

            top1.GetComponent<Light>().enabled = true;

            top2.GetComponent<Light>().enabled = true;

            top1.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            top2.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            Destroy(other.gameObject);
            Debug.Log(Time.time);
        } else if (other.tag == "rotate_block") {

            


            rotate_block_script rs = other.gameObject.GetComponent<rotate_block_script>();

          

            Transform top1 = other.transform.parent.gameObject.transform.GetChild(0).GetChild(0);

            Transform top2 = other.transform.parent.gameObject.transform.GetChild(1).GetChild(0);
         

            top1.GetComponent<Light>().enabled = true;

            top2.GetComponent<Light>().enabled = true;

            top1.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            top2.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            transform.Rotate(0.0f, rs.rotate_degree, 0.0f);
            //transform.position += transform.forward * speed * 4;
            if (p != 0)
            {
                transform.position = transform.position + transform.right * p;
            }
           
        }


    }
    */
}
