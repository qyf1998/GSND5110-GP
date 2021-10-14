using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    public GameObject Player;
    public GameObject placeManager;
    public GameObject playerlight;
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.gameObject == Player) 
        {

            playerlight.SetActive(true);
            placeManager.GetComponent<PlaceObjectManager>().canRed = true;
            this.gameObject.SetActive(false);
        }
    }
}
