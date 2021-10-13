using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckScript : MonoBehaviour
{


    public GameObject cam, suck;
    public LayerMask SuckLayer;

    Vector3 object_pos, cam_pos;
    RaycastHit hit;
    public float speed = 10f;


    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        suck.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        suck.SetActive(false);
        if (Input.GetAxis("LT") != 0)
        {
            suck.SetActive(true);
            float step = speed * Time.deltaTime;
            cam_pos = cam.transform.position;
            if (Physics.Raycast(cam_pos, cam.transform.forward, out hit, 100f, SuckLayer))
            {

                object_pos = hit.collider.gameObject.transform.position;
                m_Rigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                // m_Rigidbody.AddForce(transform.up * 20f );


                // hit.collider.gameObject.transform.position = Vector3.MoveTowards(object_pos, cam_pos, step);
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce((cam_pos- object_pos));


               // print("object postion is :  " + object_pos);
               //print("camera postion is :  " + cam_pos);
               //print("-------------------------------------------------");
            }
        }

    }


   // bool HitCheck()
   // {
   //     RaycastHit hit;
   //     return Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 999f, SuckLayer);

   // }
}
