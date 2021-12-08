using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTpDown : MonoBehaviour
{

    public Transform target;
    // Start is called before the first frame update

    [SerializeField] Transform player;
   

    void OnTriggerEnter(Collider col)
   {
       if (col.tag == "Player") {
           player.transform.position = target.position;
       }
   }
}
