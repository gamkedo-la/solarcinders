using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public GameObject target;
    public GameObject anchor;
    public float speed;
    float step;
    public float mod = 20;
    public float POW;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        

        float dist = Vector3.Distance(target.transform.position, gameObject.transform.position);

        
            speed = Mathf.Pow(dist, POW) + mod;

            step = speed * Time.deltaTime;

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, anchor.transform.position, step);
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, step);
        }
    }
}
