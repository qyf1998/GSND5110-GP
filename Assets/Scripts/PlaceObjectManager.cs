//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlaceObjectManager : MonoBehaviour
//{
//    // Start is called before the first frame update
//     public GameObject cam;
//     public GameObject tp1, tp2;
//     public LayerMask GroundLayer;


//    void Start()
//    {
//        cam = GameObject.FindGameObjectWithTag("MainCamera");
//    }

//    void Update()
//    {
//        if (Input.GetMouseButton(0)) {
//            Vector3 pos = new Vector3 (0,0,0);
//            pos = HitPoint();
//            tp1.transform.position = pos + new Vector3 (0, 3, 0);
//            return;
//        }

//        if (Input.GetMouseButton(1)) {
//            Vector3 pos = new Vector3 (0,0,0);
//            pos = HitPoint();
//            tp2.transform.position = pos + new Vector3 (0, 3, 0);
//            return;
//        }


//    }

//    Vector3 HitPoint(){
//        RaycastHit hit;
//        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 999f, GroundLayer);
//        return hit.point;
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectManager : MonoBehaviour
{
// Start is called before the first frame update
public GameObject cam;
public GameObject tp1, tp2;
public GameObject curTp1, curTp2;
public LayerMask GroundLayer;
public LayerMask WallLayer;
public int CurrentHit;
public Light lt; 
public Vector3 HitVector;
public float angleX, angleY;
public bool isRed = true;
public bool canRed = false;
public bool canBlue = false;
void Start()
{
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        
}

void Update()
{
        if (curTp1 && curTp2)
        {

        }
        if (Input.GetButton("RB"))
        {
            if (isRed&&canRed)
            {
                lt.color = Color.red;
            }
            else if(!isRed&&canBlue)
            {
                lt.color = Color.cyan;
            }
        }

        if (Input.GetButtonUp("RB"))
        {
            lt.color = Color.white;
           // print("回复白色");
        }

        // mouse left
        if (Input.GetButtonUp("RB")&&isRed&&canRed)
        {
                Vector3 pos = new Vector3(0, 0, 0);
                pos = HitPoint();
                 print("12");
                // Ground
                if (CurrentHit == 10)
                {
                        if (curTp1)
                                GameObject.Destroy(curTp1);
                        curTp1 = GameObject.Instantiate(tp1, pos, Quaternion.Euler(HitVector.x, HitVector.y+90, HitVector.z));
                        angleX = Vector3.Angle(cam.transform.forward, curTp1.transform.right);
                        angleY = Vector3.Angle(cam.transform.up, curTp1.transform.up);
                        if (angleX > 90)
                        {
                                print("反转了");
                                curTp1.transform.Rotate(new Vector3(0, 180, 0));
                        }
                        if (angleY > 90)
                        {
                                print("反转上下");
                                curTp1.transform.Rotate(new Vector3(180, 0, 0));
                        }
                        if (curTp2)
                        {
                                curTp2.GetComponent<TpOnRight>().tp2 = curTp1;
                                curTp1.GetComponent<TpOnLeft>().tp2 = curTp2;
                        }
                        // curTp1.transform.position = pos + new Vector3(0, 3, 0);

                }

                // wall
                if (CurrentHit == 9)
                {
                        if (curTp1)
                                GameObject.Destroy(curTp1);
                        curTp1 = GameObject.Instantiate(tp1, pos, Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y + 90, 90));
                        // curTp1.transform.rotation=(new Vector3(Vector3.Angle(cam.transform.forward, curTp1.transform.up),0,0));
                        angleX = Vector3.Angle(cam.transform.forward, curTp1.transform.right);
                        angleY = Vector3.Angle(cam.transform.up, curTp1.transform.up);
                        if (angleX> 90)
                        {
                                print("反转了");
                                curTp1.transform.Rotate(new Vector3(0, 180, 0));
                        }
                        if (angleY > 90)
                        {
                                print("反转上下");
                                curTp1.transform.Rotate(new Vector3(180, 0, 0));
                        }
                        if (curTp2)
                        {
                                curTp2.GetComponent<TpOnRight>().tp2 = curTp1;
                                curTp1.GetComponent<TpOnLeft>().tp2 = curTp2;
                        }
                        // curTp1.transform.position = pos + new Vector3(0, 3, 0);
                }
            
            isRed = false;
            if (canRed && !canBlue)
            {
                isRed = true;
            }
                return;
        }

        if (Input.GetButtonUp("RB")&&!isRed&&canBlue)
        {
            print("12");
            Vector3 pos = new Vector3(0, 0, 0);
                pos = HitPoint();
                if (CurrentHit == 10)
                {
                        if (curTp2)
                                GameObject.Destroy(curTp2);
                        curTp2 = GameObject.Instantiate(tp2, pos, Quaternion.Euler(HitVector.x, HitVector.y + 90, HitVector.z));
                        angleX = Vector3.Angle(cam.transform.forward, curTp2.transform.right);
                        angleY = Vector3.Angle(cam.transform.up, curTp2.transform.up);
                        if (angleX > 90)
                        {
                                print("反转了");
                                curTp2.transform.Rotate(new Vector3(0, 180, 0));
                        }
                        if (angleY > 90)
                        {
                                print("反转上下");
                                curTp2.transform.Rotate(new Vector3(180, 0, 0));
                        }

                        if (curTp1)
                        {
                                curTp2.GetComponent<TpOnRight>().tp2 = curTp1;
                                curTp1.GetComponent<TpOnLeft>().tp2 = curTp2;
                        }
                        //curTp2.transform.position = pos + new Vector3(0, 3, 0);

                }
                if (CurrentHit == 9)
                {
                        if (curTp2)
                                GameObject.Destroy(curTp2);
                        curTp2 = GameObject.Instantiate(tp2, pos, Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y + 90, 90));
                        angleX = Vector3.Angle(cam.transform.forward, curTp2.transform.right);
                        angleY = Vector3.Angle(cam.transform.up, curTp2.transform.up);
                        if (angleX > 90)
                        {
                                print("反转了");
                                curTp2.transform.Rotate(new Vector3(0, 180, 0));
                        }
                        if (angleY > 90)
                        {
                                print("反转上下");
                                curTp2.transform.Rotate(new Vector3(180, 0, 0));
                        }

                        if (curTp1)
                        {
                                curTp2.GetComponent<TpOnRight>().tp2 = curTp1;
                                curTp1.GetComponent<TpOnLeft>().tp2 = curTp2;
                        }
                        // curTp1.transform.position = pos + new Vector3(0, 3, 0);
                }

            isRed = true;
                return;
        }
       
    }

Vector3 HitPoint()
{
        RaycastHit hit;
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 999f);
        if (hit.collider.gameObject.layer == 10)
        {
                CurrentHit = 10;
        }
        else if (hit.collider.gameObject.layer == 9)
        {
                CurrentHit = 9;
        }
        else
        {
                CurrentHit = -1;
        }
        HitVector = hit.collider.gameObject.transform.rotation.eulerAngles;
        //print(hit.collider.gameObject.name + HitVector);
        return hit.point;
}
}
