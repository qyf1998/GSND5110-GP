using DG.Tweening;
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

           // Col.gameObject.gameObject.layer = 0;
            Col.gameObject.transform.DOShakePosition(3f, 0.3f, 10, 20);
            Destroy(Col.gameObject, 1.5f);
            //print(Col.gameObject);
        }
    }
}
