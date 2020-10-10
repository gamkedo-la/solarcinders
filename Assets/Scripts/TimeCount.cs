using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{

    float StopWatch = 0;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        StopWatch += Time.deltaTime;
        if(text!=null)
        {
            text.text = StopWatch.ToString();
        }
        
    }
}
