using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{

    public Text number;


    // Start is called before the first frame update
    void Start()
    {
        number.text = GameObject.Find("Ship").GetComponent<Score>().score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
