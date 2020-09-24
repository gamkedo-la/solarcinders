using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{ 
    public float x;
    public float y;

    GameObject player;

    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Ship");

    }

    // Update is called once per frame
    void Update()
    {

        temp.z = transform.position.z;
        temp.y = player.transform.position.y + y;
        temp.x = player.transform.position.x + x;

        if (temp.y > 14)
        {
            temp.y = 14;
        }
        if (temp.y < -9)
        {
            temp.y = -9;
        }
        if (temp.x > 22)
        {
            temp.x = 22;
        }
        if (temp.x < -22)
        {
            temp.x = -22;
        }

        transform.position = temp;


    }
}
