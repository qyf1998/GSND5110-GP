using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractManager : MonoBehaviour
{
    public GameObject cam, inter_Obj, Player, IDDoor, IDDoor2;
    Vector3 cam_pos, object_pos;
    Animator anim;
    public Text message1, message2;
    public Image image;
    public Sprite s, n;
    public bool hasID = false;
    [SerializeField] Transform head, theRealPlayer, playerView;
    [SerializeField] GameObject suckTutorial;
    [SerializeField] GameObject portalTutorial;
    

    RaycastHit hit;// Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        print("hasID" + hasID);

        if (hasID)
        {
            head.LookAt(theRealPlayer);
            head.transform.Rotate(new Vector3(0, -90, -90));
        }
        cam_pos = cam.transform.position;
        if (Physics.Raycast(cam_pos, cam.transform.forward, out hit, 5f))
        {

            Debug.DrawRay(cam_pos, hit.point - cam_pos, Color.red);

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

                        GameObject hint = inter_Obj.transform.Find("Hint").gameObject;
                        if (hint != null && inter_Obj.GetComponent<DoorManager>().canOpen)
                        {
                            Destroy(hint);
                        }



                    }
                }
                if (hit.collider.gameObject.tag == "FlashLight")
                {
                    message1.text = "Press";
                    image.sprite = s;
                    message2.text = "to pick portal bulb";
                    if (Input.GetButtonDown("Interact"))
                    {

                        object_pos = hit.collider.gameObject.transform.position;
                        inter_Obj = hit.collider.gameObject;
                        if (inter_Obj.GetComponent<RedLight>())
                        {
                            inter_Obj.GetComponent<RedLight>().isPicked = true;
                        }
                        else if (inter_Obj.GetComponent<BlueLight>())
                        {
                            inter_Obj.GetComponent<BlueLight>().isPicked = true;
                        }
                        StartCoroutine(ShowPortalTutorial());

                    }
                }

                if (hit.collider.gameObject.tag == "ID")
                {
                    message1.text = "Press";
                    image.sprite = s;
                    message2.text = "to pick ID card";
                    if (Input.GetButtonDown("Interact"))
                    {
                        inter_Obj = hit.collider.gameObject;
                        hasID = true;
                        IDDoor.GetComponent<DoorManager>().needKey = false;
                        IDDoor.GetComponent<DoorManager>().canOpen = true;
                        IDDoor2.GetComponent<DoorManager>().needKey = false;
                        IDDoor2.GetComponent<DoorManager>().canOpen = true;
                        Destroy(inter_Obj);

                        StartCoroutine(lookAtZombie());
                        
                        


                    }
                }
                if (hit.collider.gameObject.tag == "Book")
                {
                    message1.text = "May the Light Fills";
                    image.enabled = false;
                    message2.text = "You With Determination";
                   
                } else{
                    image.enabled = true;
                }

                if (hit.collider.gameObject.tag == "SuckLight")
                {
                    message1.text = "Press";
                    image.sprite = s;
                    message2.text = "to pick abosorb bulb";
                    if (Input.GetButtonDown("Interact"))
                    {

                        object_pos = hit.collider.gameObject.transform.position;
                        inter_Obj = hit.collider.gameObject;
                        inter_Obj.layer = 1;
                        inter_Obj.GetComponent<suckLightIntro>().l.enabled = false;
                        inter_Obj.GetComponent<suckLightIntro>().l2.enabled = false;
                        inter_Obj.GetComponent<suckLightIntro>().enabled = false;
                        //print("����suck");
                        Player.GetComponent<SuckScript>().canSuck = true;
                        Destroy(inter_Obj);
                        StartCoroutine(ShowSuckTutorial());


                    }
                }

            }
            else
            {
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

    IEnumerator ShowSuckTutorial()
    {
        suckTutorial.SetActive(true);
        yield return new WaitForSeconds(8f);
        suckTutorial.SetActive(false);
    }

    IEnumerator ShowPortalTutorial()
    {
        portalTutorial.SetActive(true);
        yield return new WaitForSeconds(8f);
        portalTutorial.SetActive(false);
    }

    IEnumerator lookAtZombie()
    {   
        Debug.Log("triggered");
        StartCoroutine(StartCoroutineIE(2f));
        yield return new WaitForSeconds(2f);
        Vector3  _direction = (head.position - theRealPlayer.position).normalized;
        theRealPlayer.transform.rotation = Quaternion.LookRotation(new Vector3(_direction.x, 0 ,_direction.z));
        playerView.transform.rotation = Quaternion.LookRotation(new Vector3(-50, 0, 0));
    }


    IEnumerator StartCoroutineIE(float i)
    {
        while (i > 0)
        {
            playerView.LookAt(head);
            yield return null;
            i -= Time.deltaTime;
        }
    }

}
