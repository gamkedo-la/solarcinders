using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExplosion : MonoBehaviour
{
    float countUp = 1;
    float m = 15;
    float b = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        countUp += Time.deltaTime;
        b += Time.deltaTime * m;
        Vector3 s = new Vector3(b, b, b);

        transform.localScale = s;

        if (countUp > 1.4f)
        {

            Destroy(gameObject);
        }

    }
}
