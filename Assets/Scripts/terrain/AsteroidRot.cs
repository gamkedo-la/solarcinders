﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRot : MonoBehaviour
{

    Vector3 Rot = new Vector3(0, 0, 0);

    float RotSpeed;

    Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {
        Rot = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        transform.rotation = Random.rotation;

        transform.localScale = new Vector3(Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f));

        axis = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        RotSpeed = Random.Range(40.0f, 60.0f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(axis, (RotSpeed * Time.deltaTime));
        
    }
}
