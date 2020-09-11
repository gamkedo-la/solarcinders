using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairTarget : MonoBehaviour
{

    public GameObject A;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 temp = gameObject.transform.position;
        temp.x = A.transform.position.x;
        temp.y = A.transform.position.y;
        temp.z = gameObject.transform.position.z;
        gameObject.transform.position = temp;
    }
}
