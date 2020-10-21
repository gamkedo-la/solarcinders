﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTower : MonoBehaviour
{

    Vector3 scaler = new Vector3(0,0,0);
    Vector3 rot = new Vector3(0, 0, 0);

    float S;
    Vector3 temp = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        S = Random.Range(6.0f, 10.0f);

        scaler = new Vector3(S, S, S);

        rot.y = Random.Range(0, 4) * 90;

        transform.localScale = scaler;
        transform.rotation = Quaternion.Euler(rot);

        if(Mathf.Abs(transform.position.x) - (2.5f * S ) < 20)
        {

            if(transform.position.x < 0)
            {
                temp = gameObject.transform.position;
                temp.x -= (temp.x - (2.5f * S) - 15);
                gameObject.transform.position = temp;

            }

            if (transform.position.x > 0)
            {
                temp = gameObject.transform.position;
                temp.x += (temp.x - (2.5f * S) - 15);
                gameObject.transform.position = temp;

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
