using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAnchor : MonoBehaviour
{

    public GameObject A;

    Vector3 temp = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(A!=null)
        {
            temp = gameObject.transform.position;
            temp.x = A.transform.position.x;
            temp.y = A.transform.position.y;
            temp.z = gameObject.transform.position.z;
            gameObject.transform.position = temp;
            
        }
    }
}
