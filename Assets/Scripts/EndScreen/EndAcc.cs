using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndAcc : MonoBehaviour
{

    public Text number;
    public Text Score;

    public int multiplier;

    int shots;
    int hits;

    float acc;

    public int s;

    // Start is called before the first frame update
    void Start()
    {

        acc = hits / shots;

        number.text = acc.ToString();

        s = Mathf.RoundToInt(acc * multiplier);

        Score.text = s.ToString();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
