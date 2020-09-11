using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{

    public GameObject star;
    public float timer = 0;



    // Start is called before the first frame update
    void Start()
    {

        
           
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
            timer = Random.Range(0.01f, 0.1f);


        }
        else
        {

            timer -= Time.deltaTime;

        }


    }

   

    
}
