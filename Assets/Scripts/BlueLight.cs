using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLight : MonoBehaviour
{
    public GameObject Player;
    public GameObject placeManager;
    public bool isPicked;
    void Start()
    {
        isPicked = false;
    }
    void Update()
    {
        if (isPicked)
        {
           
            placeManager.GetComponent<PlaceObjectManager>().canBlue = true;
            this.gameObject.SetActive(false);
        }
    }
}
