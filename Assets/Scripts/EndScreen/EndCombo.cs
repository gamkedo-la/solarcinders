using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCombo : MonoBehaviour
{

    public Text number;
    public Text Score;

    int c;

    public int s;

    public int multiplier;

    // Start is called before the first frame update
    void Start()
    {

        c = GameObject.Find("Ship").GetComponent<Score>().LongestCombo;

        s = c * multiplier;

        number.text = c.ToString();

        Score.text = s.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
