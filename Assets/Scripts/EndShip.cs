using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndShip : MonoBehaviour
{

    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.z += speed * Time.deltaTime;
        transform.position = temp;
    }
}
