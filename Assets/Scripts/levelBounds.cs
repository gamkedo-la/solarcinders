using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelBounds : MonoBehaviour
{

    public float x;
    public float yMin;
    public float yMax;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        z = GameObject.Find("Main Camera").GetComponent<Camera>().farClipPlane;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
