using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{

    public GameObject star;
    public float timer = 0;

    public float resetMin;
    public float resetMax;


    // Start is called before the first frame update
    void Start()
    {

        if(resetMin == 0)
        {
            resetMin = 0.01f;
            resetMax = 0.1f;

        }

        timer = Random.Range(resetMin, resetMax);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer <= 0)
        {

            Vector3 spawnPosition = gameObject.transform.position;

            spawnPosition.y += Random.Range(-100.0f, 100.0f);
            spawnPosition.x += Random.Range(-100.0f, 100.0f);

            

            Instantiate(star, spawnPosition, transform.rotation);
            timer = Random.Range(resetMin, resetMax);


        }
        else
        {

            timer -= Time.deltaTime;

        }



    }

   

    
}
