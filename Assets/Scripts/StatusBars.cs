﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBars : MonoBehaviour
{

    public Slider Fill;
    

    public void SetFill(float I)
    {
        Fill.value = I;

    }

    
}
