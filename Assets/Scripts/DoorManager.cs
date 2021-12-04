using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    
    public Animator anim;
    public AudioClip movedoor;
    public AudioSource AS;
    public bool canOpen, needKey,isStucked,isOpen;// Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        AS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound() {
        AS.clip = movedoor;
        AS.Play();
    }
}
