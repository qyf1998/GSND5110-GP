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


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectManager : MonoBehaviour
{
// Start is called before the first frame update
public GameObject cam;
public GameObject tp1, tp2, tp3,Enemy;
public GameObject curTp1, curTp2, curTp3,enemy;
public LayerMask GroundLayer;
public LayerMask WallLayer;
public int CurrentHit;
public Light lt; 
public Vector3 HitVector;
public float angleX, angleY;
public AudioSource AS;
public static bool isRed = true;
public bool canRed = false;
public bool canBlue = false;
// [SerializeField] GameObject PreviewPortalOk;
// [SerializeField] GameObject PreviewPortalNotOk; 
// public bool CanPlacePortal = true; 
void Start()
{
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        
}

void Update()
    {


        // updatePortalPreview();

        placePortal();

        //     if (isRed&&canRed)
        //     {
        //         lt.color = Color.red;
        //     }
        //     else if(!isRed&&canBlue)
        //     {
        //         lt.color = Color.cyan;
        //     }

        // if (Input.GetButtonUp("RB"))
        // {
        //     lt.color = Color.white;
        //     // print("回复白色");
        // }

        

    }


//     private void placePortalPreview()
//     {
 
//             Vector3 pos = new Vector3(0, 0, 0);
//             pos = HitPoint();
//             // wall
//             if (CurrentHit == 10)
//             {
//                 if (previewTpOk)
//                     GameObject.Destroy(previewTpOk);
//                 // if (CanPlacePortal)
//                 // {
//                 //         PreviewPortalOk.GetComponent<MeshRenderer>().material.color = Color.blue;
//                 // } 
//                 // else
//                 // {
//                 //         PreviewPortalOk.GetComponent<MeshRenderer>().material.color = Color.red;     
//                 // }
//                 previewTpOk = GameObject.Instantiate(PreviewPortalOk, pos, Quaternion.Euler(HitVector.x, HitVector.y + 90, HitVector.z));
//                 angleX = Vector3.Angle(cam.transform.forward, previewTpOk.transform.right);
//                 angleY = Vector3.Angle(cam.transform.up, previewTpOk.transform.up);
//                 if (angleX > 90)
//                 {
//                     print("反转了");
//                     previewTpOk.transform.Rotate(new Vector3(0, 180, 0));
//                 }
//                 if (angleY > 90)
//                 {
//                     print("反转上下");
//                     previewTpOk.transform.Rotate(new Vector3(180, 0, 0));
//                 }
//                 // curTp1.transform.position = pos + new Vector3(0, 3, 0);
//             }
        
//     }
//     private void updatePortalPreview()
//     {
//         if (Input.GetButton("RB"))
//         {
//             placePortalPreview();
//         }
//     }



    private void placePortal()
    {
        // mouse left
                if (Input.GetButtonUp("RB") && isRed && canRed)
                {
                Vector3 pos = new Vector3(0, 0, 0);
                pos = HitPoint();
                print("12");
                // wall
                if (CurrentHit == 10)
                {
                        if (curTp1)
                        GameObject.Destroy(curTp1);
                        curTp1 = GameObject.Instantiate(tp1, pos, Quaternion.Euler(HitVector.x, HitVector.y + 90, HitVector.z));
                       
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
            // enemy wall
                if (CurrentHit == 15)
                {
                    Debug.Log("place tp3");
                    if (curTp3)
                        GameObject.Destroy(curTp3);
                    curTp3 = GameObject.Instantiate(tp3, pos, Quaternion.Euler(HitVector.x, HitVector.y + 90, HitVector.z));
                    enemy = GameObject.Instantiate(Enemy, pos, Quaternion.Euler(HitVector.x, HitVector.y, HitVector.z));
                enemy.transform.position -= enemy.transform.forward.normalized * 3;
                angleX = Vector3.Angle(cam.transform.forward, curTp3.transform.right);
                    angleY = Vector3.Angle(cam.transform.up, curTp3.transform.up);
                    if (angleX > 90)
                    {
                        print("反转了");
                        curTp3.transform.Rotate(new Vector3(0, 180, 0));
                       enemy.transform.Rotate(new Vector3(0, 180, 0));
                }
                    if (angleY > 90)
                    {
                        print("反转上下");
                        curTp3.transform.Rotate(new Vector3(180, 0, 0));
                        enemy.transform.Rotate(new Vector3(180, 0, 0));

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

            // // ground
            // if (CurrentHit == 9)
            // {
            //         if (curTp1)
            //                 GameObject.Destroy(curTp1);
            //         curTp1 = GameObject.Instantiate(tp1, pos, Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y + 90, 90));
            //         // curTp1.transform.rotation=(new Vector3(Vector3.Angle(cam.transform.forward, curTp1.transform.up),0,0));
            //         angleX = Vector3.Angle(cam.transform.forward, curTp1.transform.right);
            //         angleY = Vector3.Angle(cam.transform.up, curTp1.transform.up);
            //         if (angleX> 90)
            //         {
            //                 print("反转了");
            //                 curTp1.transform.Rotate(new Vector3(0, 180, 0));
            //         }
            //         if (angleY > 90)
            //         {
            //                 print("反转上下");
            //                 curTp1.transform.Rotate(new Vector3(180, 0, 0));
            //         }
            //         if (curTp2)
            //         {
            //                 curTp2.GetComponent<TpOnRight>().tp2 = curTp1;
            //                 curTp1.GetComponent<TpOnLeft>().tp2 = curTp2;
            //         }
            //         // curTp1.transform.position = pos + new Vector3(0, 3, 0);
            // }

            

        if (Input.GetButtonUp("RB") && !isRed && canBlue)
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

            // enemy wall
            if (CurrentHit == 15)
            {
                Debug.Log("place tp3");
                if (curTp3)
                    GameObject.Destroy(curTp3);
                curTp3 = GameObject.Instantiate(tp3, pos, Quaternion.Euler(HitVector.x, HitVector.y+90, HitVector.z));
                enemy = GameObject.Instantiate(Enemy, pos, Quaternion.Euler(HitVector.x, HitVector.y, HitVector.z));
                enemy.transform.position -= enemy.transform.forward.normalized * 3;
                angleX = Vector3.Angle(cam.transform.forward, curTp3.transform.right);
                angleY = Vector3.Angle(cam.transform.up, curTp3.transform.up);
                if (angleX > 90)
                {
                    print("反转了");
                    curTp3.transform.Rotate(new Vector3(0, 180, 0));
                    enemy.transform.Rotate(new Vector3(0, 180, 0));
                }
                if (angleY > 90)
                {
                    print("反转上下");
                    curTp3.transform.Rotate(new Vector3(180, 0, 0));
                    enemy.transform.Rotate(new Vector3(180, 0, 0));
                }


                //curTp2.transform.position = pos + new Vector3(0, 3, 0);

            }


            // if (CurrentHit == 9)
            // {
            //         if (curTp2)
            //                 GameObject.Destroy(curTp2);
            //         curTp2 = GameObject.Instantiate(tp2, pos, Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y + 90, 90));
            //         angleX = Vector3.Angle(cam.transform.forward, curTp2.transform.right);
            //         angleY = Vector3.Angle(cam.transform.up, curTp2.transform.up);
            //         if (angleX > 90)
            //         {
            //                 print("反转了");
            //                 curTp2.transform.Rotate(new Vector3(0, 180, 0));
            //         }
            //         if (angleY > 90)
            //         {
            //                 print("反转上下");
            //                 curTp2.transform.Rotate(new Vector3(180, 0, 0));
            //         }

            //         if (curTp1)
            //         {
            //                 curTp2.GetComponent<TpOnRight>().tp2 = curTp1;
            //                 curTp1.GetComponent<TpOnLeft>().tp2 = curTp2;
            //         }
            //         // curTp1.transform.position = pos + new Vector3(0, 3, 0);
            // }

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
        else if (hit.collider.gameObject.layer == 15)
        {
            CurrentHit = 15;
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
