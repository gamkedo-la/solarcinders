using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTotal : MonoBehaviour
{

    public GameObject Ac;
    public GameObject Co;

    int FS;

    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        FS = GameObject.Find("Ship").GetComponent<Score>().score + Ac.GetComponent<EndAcc>().s + Co.GetComponent<EndCombo>().s;

        Score.text = FS.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
