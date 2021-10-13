using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject sword;
    bool active_sword;

    void Start()
    {
        sword.SetActive(false);
        active_sword = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Sword") != 0)
        if (Input.GetButtonDown("Sword"))
        {
            if (active_sword)
            {
                sword.SetActive(false);
                active_sword = false;
            } else
            {
                sword.SetActive(true);
                active_sword = true;
            }
        }

    }

}
