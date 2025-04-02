using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_mob : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float velx = 1.0f;
    private int hp;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        vel.x = -velx;
        rb2d.velocity = vel;
        transform.position = new Vector3(velx, 0, 0)*Time.deltaTime;
    
    }
}
