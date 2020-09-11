using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairTarget2 : MonoBehaviour
{

    public Transform Anchor;
    Vector3 temp = new Vector3(0,0,0);
    public int sense;

    public int yBound = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        temp = Anchor.transform.position;

        if (((Input.GetAxis("Horizontal") * sense) > 1) || ((Input.GetAxis("Horizontal") * sense) < -1))
        {
            temp.x += Input.GetAxis("Horizontal") * sense;
        }

        if (((Input.GetAxis("Vertical") * sense) > 1) || ((Input.GetAxis("Vertical") * sense) < -1))
        {
            temp.y += Input.GetAxis("Vertical") * sense;
        }

        if (temp.y > yBound)
        { temp.y = yBound; }
        if (temp.y < -(yBound /*+ bottomBuffer*/))
        { temp.y = -yBound /* + bottomBuffer*/; }

        gameObject.transform.position = temp;
    }
}
