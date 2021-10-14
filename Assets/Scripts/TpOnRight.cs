//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TpOnRight : MonoBehaviour
//{

//    public GameObject tp2;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    void OnTriggerEnter(Collider Col) {
//        print("砰！");
//        Col.transform.position = tp2.transform.position + new Vector3 (0,0,2);
//    }
//}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpOnRight : MonoBehaviour
{

    public GameObject tp2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider Col)
    {
       // print("进入1");
       //  print("角度之前" + (Col.transform.eulerAngles.y));
        Col.gameObject.transform.Rotate(0, 180 + tp2.transform.eulerAngles.y - this.transform.eulerAngles.y, 0);
        Col.transform.position = tp2.transform.position + tp2.transform.right.normalized * -3;
        //print(tp2.transform.right.normalized * 2);
       // print("角度之后" + (Col.transform.eulerAngles.y));
        //print("角度" + (tp2.transform.eulerAngles.y - this.transform.eulerAngles.y));
        /*
        Vector3 Vel = Col.GetComponent<Rigidbody>().velocity;
        Vector3 tp1Right = this.transform.right;
        Vector3 tp2Right = tp2.transform.right;
        double[] vectorBefore = { tp1Right.x, tp1Right.y, tp1Right.z };
        double[] vectorAfter = { tp2Right.x, tp2Right.y, tp2Right.z };
        double[,] res = Calculation(vectorBefore, vectorAfter);
        Col.GetComponent<Rigidbody>().velocity = new Vector3((float)(res[0, 0] * Vel.x + res[0, 1] * Vel.y + res[0, 2] * Vel.z), (float)(res[1, 0] * Vel.x + res[1, 1] * Vel.y + res[1, 2] * Vel.z), (float)(res[2, 0] * Vel.x + res[2, 1] * Vel.y + res[2, 2] * Vel.z));
   */
    }

    /*
    double[,] Calculation(double[] vectorBefore, double[] vectorAfter)
        {
            double[] rotationAxis;
            double rotationAngle;
            double[,] rotationMatrix;
            rotationAxis = CrossProduct(vectorBefore, vectorAfter);
            rotationAngle = Math.Acos(DotProduct(vectorBefore, vectorAfter) / Normalize(vectorBefore) / Normalize(vectorAfter));
            rotationMatrix = RotationMatrix(rotationAngle, rotationAxis);
            return rotationMatrix;
        }

        double[] CrossProduct(double[] a, double[] b)
        {
            double[] c = new double[3];

            c[0] = a[1] * b[2] - a[2] * b[1];
            c[1] = a[2] * b[0] - a[0] * b[2];
            c[2] = a[0] * b[1] - a[1] * b[0];

            return c;
        }

        double DotProduct(double[] a, double[] b)
        {
            double result;
            result = a[0] * b[0] + a[1] * b[1] + a[2] * b[2];

            return result;
        }

        double Normalize(double[] v)
        {
            double result;

            result = Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);

            return result;
        }

        double[,] RotationMatrix(double angle, double[] u)
        {
            double norm = Normalize(u);
            double[,] rotatinMatrix = new double[3, 3];

            u[0] = u[0] / norm;
            u[1] = u[1] / norm;
            u[2] = u[2] / norm;

            rotatinMatrix[0, 0] = Math.Cos(angle) + u[0] * u[0] * (1 - Math.Cos(angle));
            rotatinMatrix[0, 0] = u[0] * u[1] * (1 - Math.Cos(angle) - u[2] * Math.Sin(angle));
            rotatinMatrix[0, 0] = u[1] * Math.Sin(angle) + u[0] * u[2] * (1 - Math.Cos(angle));

            rotatinMatrix[0, 0] = u[2] * Math.Sin(angle) + u[0] * u[1] * (1 - Math.Cos(angle));
            rotatinMatrix[0, 0] = Math.Cos(angle) + u[1] * u[1] * (1 - Math.Cos(angle));
            rotatinMatrix[0, 0] = -u[0] * Math.Sin(angle) + u[1] * u[2] * (1 - Math.Cos(angle));

            rotatinMatrix[0, 0] = -u[1] * Math.Sin(angle) + u[0] * u[2] * (1 - Math.Cos(angle));
            rotatinMatrix[0, 0] = u[0] * Math.Sin(angle) + u[1] * u[2] * (1 - Math.Cos(angle));
            rotatinMatrix[0, 0] = Math.Cos(angle) + u[2] * u[2] * (1 - Math.Cos(angle));

            return rotatinMatrix;
        }
    */

}


