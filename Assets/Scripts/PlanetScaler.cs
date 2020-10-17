using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScaler : MonoBehaviour
{

    Vector3 PScale = new Vector3(0,0,0);
    float stopWatch = 0;
    float t = 0;
    float min = 2;
    float max = 35;
    float sca;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        stopWatch += Time.deltaTime;

        t = stopWatch / 200;

        sca = Mathf.Lerp(min, max, t);

        PScale = new Vector3(sca, sca, sca);

        transform.localScale = PScale;

    }
}
