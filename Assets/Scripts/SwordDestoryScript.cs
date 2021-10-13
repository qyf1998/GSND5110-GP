using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDestoryScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider Col)
    {

        if (Col.gameObject.CompareTag("destoryable"))
        {
            print("插中啦！！！！");
            Col.gameObject.SetActive(false);
        }
    }
}
