using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairUI : MonoBehaviour
{

    public Transform Camera;
    public Transform Crosshair;
    Vector3 temp = new Vector3(0, 0, 0);
    public int XY = 10;
    public int Z = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*  temp = Crosshair.position + Camera.position;
            temp.x /= XY;
            temp.y /= XY;
            temp.z /= Z;
            temp += Camera.position;
            */

        temp = Vector3.Lerp(Crosshair.position, Camera.position, .9f);

        gameObject.transform.position = temp;


    }
}
