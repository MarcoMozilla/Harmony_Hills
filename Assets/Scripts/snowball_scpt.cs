using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowball_scpt : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        
        this.transform.position += this.transform.forward * speed;



        if (Time.time - startTime > 5) {
            Destroy(this.gameObject);
        }
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "breakable_ice") {
            Debug.Log("snow ball hit ice---");

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
