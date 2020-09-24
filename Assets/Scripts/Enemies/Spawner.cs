using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float timer;

    public float reset;

    public GameObject[] wayPoints;

    public GameObject enemy;

    int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {

            Spawn();

            timer = reset;

        }
        
    }

    void Spawn()
    {

        GameObject This = Instantiate(enemy, transform.position, Quaternion.identity);

        //This.GetComponent<Shooter>().waypoint = wayPoints[i];

        i++;

        if(i>3)
        { i = 0; }
    }

}
