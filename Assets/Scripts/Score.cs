﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text display;

    public int score = 0;

    public int Shots;
    public int Hits;

    public float acc;
    public int LongestCombo = 0;


    private void Start()
    {
        display.text = score.ToString();
    }

    public void ScoreChange(int points)
    {

        score += (points * GetComponent<Combo>().count);
        display.text = score.ToString();

    }


}
