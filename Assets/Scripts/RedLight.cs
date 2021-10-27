using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    public GameObject Player;
    public GameObject placeManager;
    public GameObject playerlight;
    public bool isPicked;
  

    void Start() {
        isPicked = false;
    }
   void Update() {
        if (isPicked) {
           // playerlight.SetActive(true);
            placeManager.GetComponent<PlaceObjectManager>().canRed = true;
            placeManager.GetComponent<PlaceObjectManager>().canBlue= true;
            this.gameObject.SetActive(false);
        }
    }
}
