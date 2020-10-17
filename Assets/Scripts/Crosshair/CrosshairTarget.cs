﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairTarget : MonoBehaviour
{

    public Transform Anchor;
    Vector3 temp = new Vector3(0,0,0);
    public int sense = 15;

    GameObject player;

    public int yBound = 20;

    bool MouseControl;

    Vector3 worldPos;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("ship");

        if (GameObject.Find("PlayerManager").GetComponent<MouseControl>().mouseCon == true)
        {
            MouseControl = true;

        }
        else
        {

            MouseControl = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (MouseControl)
        {


            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 45;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = worldPos;

        }
        else
        {


            if (Anchor != null)
            {
                temp = Anchor.transform.position;



                if (Mathf.Abs(Input.GetAxis("Horizontal") * sense) > 1)
                {
                    temp.x += Input.GetAxis("Horizontal") * sense;
                }

                if (Mathf.Abs(Input.GetAxis("Vertical") * sense) > 1)
                {
                    temp.y += Input.GetAxis("Vertical") * sense;
                }

                temp.y = Mathf.Clamp(temp.y, -yBound, yBound);

                gameObject.transform.position = temp;
            }
        }
    }
}
