using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowBall : MonoBehaviour
{
    // Start is called before the first frame update


    private Vector3 pos;
    private Quaternion rot;

    public GameObject snowball;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void makeSnowBall() {
            pos = this.transform.position;
            rot = this.transform.rotation;
        
        GameObject obj = Instantiate(snowball, pos, rot);
        obj.GetComponent<Collider>().enabled = false;
        obj.GetComponent<Collider>().enabled = true;

    }
}
