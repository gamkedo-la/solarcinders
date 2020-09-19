using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScaler : MonoBehaviour
{

    public GameObject A;
    public float scaler = 2;
    public float xBound = 20;
    public float yBound = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp = gameObject.transform.position;
        temp.x = A.transform.position.x;
        temp.y = A.transform.position.y;
        temp.z = gameObject.transform.position.z;

        if (temp.x > xBound)
        { temp.x = xBound; }
        if (temp.x < -xBound)
        { temp.x = -xBound; }
        if (temp.y > yBound)
        { temp.y = yBound; }
        if (temp.y < -yBound)
        { temp.y = -yBound; }

        temp *= scaler;

        gameObject.transform.position = temp;


    }
}
