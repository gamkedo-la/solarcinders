using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{

    public GameObject target;

    Vector3 targetPos = new Vector3(0, 0, 0);

    public float speed;
    public float step;
    public float mod = 20;
    public float POW;
    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        dist = Vector3.Distance(targetPos, gameObject.transform.position);


        

            speed = Mathf.Pow(dist, POW) + mod;


            step = speed * Time.deltaTime;

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos, step);
        


        targetPos = target.transform.position;

    }
}
