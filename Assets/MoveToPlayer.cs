using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public GameObject Player;
    public float speed = 0.1f;// Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate((Player.transform.position - this.transform.position).normalized * speed * Time.deltaTime);
    }
}
