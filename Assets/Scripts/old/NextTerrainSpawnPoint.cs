using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTerrainSpawnPoint : MonoBehaviour
{

    public Vector3 Next= new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Next = transform.position;
        Next.z += 70;

    }
}
