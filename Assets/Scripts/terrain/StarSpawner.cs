using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{

    public GameObject star;
    public float timer = 0;

    public float resetMin;
    public float resetMax;

    public float spawnMinX;
    public float spawnMaxX;

    public float spawnMinY;
    public float spawnMaxY;


    // Start is called before the first frame update
    void Start()
    {

        if(resetMin == 0)
        {
            resetMin = 0.01f;
            resetMax = 0.1f;

        }
        if (spawnMinX == 0)
        {
            spawnMinX = -100.0f;
            spawnMaxX = 100.0f;

        }

        if (spawnMinY == 0)
        {
            spawnMinY = -100.0f;
            spawnMaxY = 100.0f;

        }

        timer = Random.Range(resetMin, resetMax);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer <= 0)
        {

            Vector3 spawnPosition = gameObject.transform.position;

            spawnPosition.y += Random.Range(spawnMinY, spawnMaxY);
            spawnPosition.x += Random.Range(spawnMinX, spawnMaxX);

            

            Instantiate(star, spawnPosition, transform.rotation);
            timer = Random.Range(resetMin, resetMax);


        }
        else
        {

            timer -= Time.deltaTime;

        }



    }

   

    
}
