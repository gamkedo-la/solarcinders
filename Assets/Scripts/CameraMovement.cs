using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject ship;

    Vector3 temp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(ship!=null)
        {
            temp = ship.transform.position;
            temp.x /= 3;
            // temp.y += 5;
            temp.y /= 3;
            /*
            if (temp.y >= 0)
            {
                temp.y += 2;
            }
            else
            {
                temp.y -= 2;
            }*/

            temp.z -= 20;

            transform.position = temp;
        }

    }
}
