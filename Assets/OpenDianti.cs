using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDianti : MonoBehaviour
{
    public GameObject dianti;// Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        dianti.GetComponent<Animator>().enabled = true;
        dianti.GetComponent<AudioSource>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
