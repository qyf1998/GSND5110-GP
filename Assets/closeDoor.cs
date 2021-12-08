using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{

    [SerializeField] GameObject door;
    [SerializeField] GameObject Destorydoor;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.SetActive(true);
            Destroy(Destorydoor);
        }
    }
}
