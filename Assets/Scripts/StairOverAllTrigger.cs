using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairOverAllTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Down, up;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Down.SetActive(true);
        // up.SetActive(true);
    }

}
