using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndAcc : MonoBehaviour
{

    public Text number;
    public Text Score;

    public int multiplier;

    public float shots;
    public float hits;

    public float acc;

    public int s;

    // Start is called before the first frame update
    void Start()
    {

        hits = GameObject.Find("Ship").GetComponent<Score>().Hits;
        shots = GameObject.Find("Ship").GetComponent<Score>().Shots;

        acc = Mathf.Round((hits / shots) * 1000.0f) / 10.0f;

        number.text = acc.ToString();

        s = Mathf.RoundToInt(acc * multiplier);

        Score.text = s.ToString();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
