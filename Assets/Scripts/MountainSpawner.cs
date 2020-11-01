using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainSpawner : MonoBehaviour
{

    public GameObject[] mountains;


    public float timer = 0;

    public float resetMin;
    public float resetMax;

    // Start is called before the first frame update
    void Start()
    {

        timer = Random.Range(resetMin, resetMax);


    }

    // Update is called once per frame
    void Update()
    {


        if (timer <= 0)
        {

            Vector3 spawnPosition = gameObject.transform.position;





            Instantiate(mountains[Random.Range(0,mountains.Length)], spawnPosition, transform.rotation);
            timer = Random.Range(resetMin, resetMax);


        }
        else
        {

            timer -= Time.deltaTime;

        }

    }
}
