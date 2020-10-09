using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRot : MonoBehaviour
{

    Vector3 Rot = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        Rot = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        transform.rotation.eulerAngles.Set(Rot.x, Rot.y, Rot.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
