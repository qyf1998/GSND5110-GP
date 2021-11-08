using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePortalCheck : MonoBehaviour
{
    GameObject portalCheck;
    void Start()
    {
        portalCheck = GameObject.Find("PlaceObjectManager");
        // portalCheck.GetComponent<PlaceObjectManager>().CanPlacePortal = true;
        // GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    //! change preview portal color to RED if not feasible 
    void OnTriggerEnter(Collider other)
    {

        //portalCheck.GetComponent<PlaceObjectManager>().CanPlacePortal = false;
        Debug.Log("entered" + other.name);
        
    }

    void OnTriggerExit(Collider other)
    {
        //portalCheck.GetComponent<PlaceObjectManager>().CanPlacePortal = true;
        Debug.Log("existed" + other.name);
    }


        
}
