using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLight : MonoBehaviour
{
    public GameObject Player;
    public GameObject placeManager;
    private void OnTriggerEnter(Collider other)
    {
      //  print(other.gameObject);
        if (other.gameObject == Player)
        {
            placeManager.GetComponent<PlaceObjectManager>().canBlue = true;
            this.gameObject.SetActive(false);
        }
    }
}
