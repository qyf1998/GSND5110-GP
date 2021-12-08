using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDeath : MonoBehaviour
{
    public GameObject penal;
    public AudioSource AS;// Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            AS.Play();
            penal.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
