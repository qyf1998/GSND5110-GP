using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScare : MonoBehaviour
{
    public GameObject scare;
    public string target;// Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == target) {
            print("gui1");
            if (scare) {
                print("gui2");
                scare.SetActive(true);
            }
            
        }
    }
}
