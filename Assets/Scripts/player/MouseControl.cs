﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{

    public bool mouseCon;

    // Start is called before the first frame update
    void Start()
    {
        
        if(PlayerPrefs.GetInt("MouseCon") == 1)
        {

            mouseCon = true;
            Debug.Log("mouse on");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
