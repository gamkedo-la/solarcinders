using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExplosion : MonoBehaviour
{
    float countUp = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        countUp += (Time.deltaTime / 2);
        transform.localScale *= countUp;

        if (countUp > 1.15f)
        {

            Destroy(gameObject);
        }

    }
}
