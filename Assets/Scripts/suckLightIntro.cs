using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suckLightIntro : MonoBehaviour
{
    public Light l,l2;
    public GameObject suck1, suck2, suck3,suck4,suck5,suck6,suck7,suck8;
    public float t = 0;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (l.intensity == 5)
        {
            suck1.GetComponent<Rigidbody>().AddForce((l.gameObject.transform.position - suck1.transform.position) *5);
            suck2.GetComponent<Rigidbody>().AddForce((l.gameObject.transform.position - suck2.transform.position) * 5);
            suck3.GetComponent<Rigidbody>().AddForce((l.gameObject.transform.position - suck3.transform.position) * 5);
            suck4.GetComponent<Rigidbody>().AddForce((l.gameObject.transform.position - suck4.transform.position) * 5);
            suck5.GetComponent<Rigidbody>().AddForce((l.gameObject.transform.position - suck5.transform.position) * 5);
            suck6.GetComponent<Rigidbody>().AddForce((l.gameObject.transform.position - suck6.transform.position) * 5);
            suck7.GetComponent<Rigidbody>().AddForce((l.gameObject.transform.position - suck7.transform.position) * 5);
            suck8.GetComponent<Rigidbody>().AddForce((l.gameObject.transform.position - suck8.transform.position) * 5);
          
          

        }
        t += Time.deltaTime;
        if (l2.range > 2.5f) {
            l2.range -= 2 * Time.deltaTime;
            l.range -= 2 * Time.deltaTime;
        }
       
        if (t > 4) {
                t = 0;
                changeLight();
           
        }
           
        

       
        
    }

    void changeLight() {
        if (l.intensity == 0)
        {
            l.intensity = 5;
            l2.intensity = 5;
            l2.range=10;
            l.range=10;

        }
        else {
            l.intensity = 0;
            l2.intensity = 0;
        }


    }
}
