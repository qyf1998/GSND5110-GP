
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public static int t = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //就是个计时器
        if (t >= 0)
            print(t++);
    }
}