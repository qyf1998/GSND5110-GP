using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light lt;// Start is called before the first frame update
    float i = 0;
    void Start()
    {
        lt = this.GetComponent < Light > ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Light")) {
            if (lt.intensity == 0)
            {
                lt.intensity = 0.5f;
            }
            else {
                lt.intensity = 0;
            }
        }

        print(i);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("flashing"))
        {
            i = 0.2f;
            StartCoroutine(Flashing());
        }
        
    }

    IEnumerator Flashing()
    {
        
        while (i > 0)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.4f));
            lt.enabled = !lt.enabled;
            i -= Time.deltaTime;
        }
        lt.enabled = true;
    }
}
