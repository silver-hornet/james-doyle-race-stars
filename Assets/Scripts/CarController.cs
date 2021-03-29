﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody theRB;
    public float maxSpeed;
    public float forwardAccel = 8f;
    public float reverseAccel = 4f;
    float speedInput;
    public float turnStrength = 180f;
    float turnInput;

    void Start()
    {
        theRB.transform.parent = null;
    }

    void Update()
    {
        speedInput = 0;

        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel;
        }

        turnInput = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));
        }

        transform.position = theRB.position;
    }

    void FixedUpdate()
    {
        theRB.AddForce(transform.forward * speedInput * 1000f);
    }
}