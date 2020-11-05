using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{

    public Text number;

    public GameObject ship;

    public int score;


    // Start is called before the first frame update
    void Start()
    {



        ship = GameObject.Find("Ship");
        score = ship.GetComponent<Score>().score;
        number.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
