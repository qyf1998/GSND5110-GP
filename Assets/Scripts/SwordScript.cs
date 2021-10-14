using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwordScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject sword, PlayerLight;
    bool active_sword;
    public GameObject cam;
    public LayerMask BreakLayer;
    bool temp = false;
    Vector3 object_pos, cam_pos;
    RaycastHit hit;
    //public float speed = 10f;


    Rigidbody m_Rigidbody;
    void Start()
    {
        sword.SetActive(false);
        active_sword = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Sword") != 0)
        if (Input.GetButtonDown("Sword"))
        {
            if (active_sword)
            {
                sword.SetActive(false);
                active_sword = false;
              
            } else
            {
                sword.SetActive(true);
                active_sword = true;
               
                //  PlayerLight.GetComponent<Light>().color = Color.yellow;

            }
        }


          

        if (Input.GetButton("LT"))
        {
            if (active_sword == true)
            {
                temp = true;
             active_sword = false;
              
                sword.SetActive(false);
              

            }
           
        }

        if (Input.GetButtonUp("LT"))
        {
            if (temp) {
                temp = false;
                sword.SetActive(true);
               // PlayerLight.GetComponent<Light>().color = Color.yellow;
                active_sword = true;
                
            }
        }
           

    }

}
