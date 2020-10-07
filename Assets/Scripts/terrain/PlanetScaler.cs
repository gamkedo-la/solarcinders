using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScaler : MonoBehaviour
{

    float countUp = 0;
    public float speed;

    Vector3 temp = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0)
        {
            speed = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        temp.x += (Time.deltaTime * speed);
        temp.y += (Time.deltaTime * speed);
        temp.z += (Time.deltaTime * speed);


        transform.localScale = temp;


    }
}
