using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTpDown : MonoBehaviour
{

    public Transform target;
    // Start is called before the first frame update
   

    void OnTriggerEnter(Collider col)
   {
       col.transform.position = target.position;
   }
}
