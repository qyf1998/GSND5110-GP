using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light lt;// Start is called before the first frame update
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
                lt.intensity = 2;
            }
            else {
                lt.intensity = 0;
            }
        }
        
    }
}
