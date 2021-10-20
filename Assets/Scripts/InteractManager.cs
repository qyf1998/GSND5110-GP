using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractManager : MonoBehaviour
{
    public GameObject cam, inter_Obj,Player;
    Vector3 cam_pos, object_pos;
    Animator anim;
    public Text message1,message2;
    public Image image;
    public Sprite s;
    RaycastHit hit;// Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
            cam_pos = cam.transform.position;
        if (Physics.Raycast(cam_pos, cam.transform.forward, out hit, 5f))
        {
            
            Debug.DrawRay(cam_pos, hit.point-cam_pos, Color.red);

            if (hit.collider.gameObject.layer == 14)
            {

                message1.gameObject.SetActive(true);
                message2.gameObject.SetActive(true);
                image.gameObject.SetActive(true);
                if (hit.collider.gameObject.tag == "Door")
                {
                    message1.text = "";
                    image.sprite = s;
                    message2.text = "";
                    if (hit.collider.gameObject.GetComponent<DoorManager>().isStucked)
                    {
                        message1.text = "";
                        image.color = Color.grey;
                        message2.text = "Stucked";
                    }
                    else if (hit.collider.gameObject.GetComponent<DoorManager>().needKey)
                    {
                        message1.text = "";
                        image.color = Color.grey;
                        message2.text = "Locked";
                    }
                    else if (hit.collider.gameObject.GetComponent<DoorManager>().canOpen)
                    {
                        message1.text = "";
                        image.color = Color.blue;
                        message2.text = "";
                    }
                    if (Input.GetButtonDown("Interact"))
                    {

                        object_pos = hit.collider.gameObject.transform.position;
                        inter_Obj = hit.collider.gameObject;
                        anim = inter_Obj.GetComponent<Animator>();
                        if (inter_Obj.GetComponent<DoorManager>().canOpen)
                        {
                            if (anim.GetBool("IsOpen"))
                            {

                                inter_Obj.GetComponent<Animator>().Play("CloseDoor");
                                inter_Obj.GetComponent<Animator>().SetBool("IsOpen", false);
                            }
                            else
                            {

                                inter_Obj.GetComponent<Animator>().Play("OpenDoor");
                                inter_Obj.GetComponent<Animator>().SetBool("IsOpen", true);
                            }
                        }



                    }
                }
                if (hit.collider.gameObject.tag == "FlashLight") {
                    message1.text = "Press";
                    image.sprite = s;
                    message2.text = "to pick the flashlight";
                    if (Input.GetButtonDown("Interact"))
                    {

                        object_pos = hit.collider.gameObject.transform.position;
                        inter_Obj = hit.collider.gameObject;
                        if (inter_Obj.GetComponent<RedLight>())
                        {
                            inter_Obj.GetComponent<RedLight>().isPicked = true;
                        }
                        else if (inter_Obj.GetComponent<BlueLight>()) {
                            inter_Obj.GetComponent<BlueLight>().isPicked = true;
                        }
                        



                    }
                }
                if (hit.collider.gameObject.tag == "SuckLight") {
                    message1.text = "Press";
                    image.sprite = s;
                    message2.text = "to pick this light bulb";
                    if (Input.GetButtonDown("Interact"))
                    {

                        object_pos = hit.collider.gameObject.transform.position;
                        inter_Obj = hit.collider.gameObject;

                        inter_Obj.GetComponent<suckLightIntro>().l.enabled = false;
                        inter_Obj.GetComponent<suckLightIntro>().l2.enabled = false;
                        inter_Obj.GetComponent<suckLightIntro>().enabled = false;
                        Player.GetComponent<SuckScript>().canSuck = true;




                    }
                }

            }
            else {
                message1.gameObject.SetActive(false);
                message2.gameObject.SetActive(false);
                image.gameObject.SetActive(false);
            }
           
        }
        else
        {
            message1.gameObject.SetActive(false);
            message2.gameObject.SetActive(false);
            image.gameObject.SetActive(false);
        }




    }
}
