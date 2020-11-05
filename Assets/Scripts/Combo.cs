using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{

    public int count;

    public Text text;

    float timer = 0;
    float reset = 5;

    public Slider Countdown;

    
    public void Add()
    {

        count++;
        timer = reset;

        if(count > GetComponent<Score>().LongestCombo)
        {

            GetComponent<Score>().LongestCombo = count;
        }

    }

    private void Start()
    {
        text.text = count.ToString();
    }

    private void Update()
    {

        timer -= Time.deltaTime * (1 + (count / 10));
        Countdown.value = timer;
        text.text = count.ToString();

        if (timer <= 0)
        {

            count = 0;

        }

    }

}
