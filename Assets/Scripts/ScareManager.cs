using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareManager : MonoBehaviour
{
    public Animator anim;
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
      //  anim = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    private void OnBecameVisible()
    {
        print("²¥·Å¶¯»­");
        anim.Play("Scare1");
    }

    void cancelSelf() {
        Destroy(zombie);
    }
}
