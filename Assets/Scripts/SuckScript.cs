using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckScript : MonoBehaviour
{


    public GameObject cam, suck,PlayerLight;
    public LayerMask SuckLayer;

    Vector3 object_pos, cam_pos;
    RaycastHit hit;
    public float speed = 10f;
    public bool canSuck = false;


    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
       // suck.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetAxis("LT") == 0)
        {
            PlayerLight.GetComponent<Light>().spotAngle = 45;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //suck.SetActive(false);
        if (Input.GetAxis("LT") != 0&canSuck)
        {
            // suck.SetActive(true
            
            PlayerLight.GetComponent<Light>().spotAngle -= 20*Time.deltaTime;
            PlayerLight.GetComponent<Light>().color = Color.white ;
            float step = speed * Time.deltaTime;
            cam_pos = cam.transform.position;
            if (Physics.Raycast(cam_pos, cam.transform.forward, out hit, 100f, SuckLayer))
            {

                object_pos = hit.collider.gameObject.transform.position;
                m_Rigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                // m_Rigidbody.AddForce(transform.up * 20f );


                // hit.collider.gameObject.transform.position = Vector3.MoveTowards(object_pos, cam_pos, step);

                // add force to the rigidbody towards player
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce((cam_pos- object_pos)*10);



               //print("object postion is :  " + object_pos);
               //print("camera postion is :  " + cam_pos);
               //print("-------------------------------------------------");
            }

            GameObject hint = hit.transform.Find("SuckHint").gameObject;
            if (hint != null)
            {
                Destroy(hint);
            }
        }
        if (Input.GetAxis("LT")==0)
        {
            PlayerLight.GetComponent<Light>().spotAngle = 45;
        }


    }

    


    // bool HitCheck()
    // {
    //     RaycastHit hit;
    //     return Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 999f, SuckLayer);

    // }

    // 没用的东西
}
