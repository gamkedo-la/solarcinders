using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScaler : MonoBehaviour
{

    public GameObject A;
   // public float scaler = 1;
    public float xBound = 20;
    public float yBound = 5;

    public float zPlane = 20;

    Vector3 temp = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        
        temp.x = A.transform.position.x;
        temp.y = A.transform.position.y;
        

        temp.z = zPlane;
        

        temp.x = Mathf.Clamp(temp.x, -xBound, xBound);
        temp.y = Mathf.Clamp(temp.y, -yBound, yBound);

       

        //temp *= scaler;

        gameObject.transform.position = temp;

        //temp = A.transform.position;


    }
}
