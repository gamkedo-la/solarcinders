using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarCrosshairMovement : MonoBehaviour
{
    public GameObject target;
    public GameObject anchor;

    Vector3 T = new Vector3(0, 0, 0);
    Vector3 A = new Vector3(0, 0, 0);

    public float speed;
    float step;
    public float mod = 20;
    public float POW;
    

    // Start is called before the first frame update
    void Start()
    {
        T = target.transform.position;
        A = anchor.transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        

        float dist = Vector3.Distance(target.transform.position, gameObject.transform.position);

        
            speed = Mathf.Pow(dist, POW) + mod;

            step = speed * Time.deltaTime;

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, A, step);
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, T, step);
        }

        T = target.transform.position;
        if(anchor!=null)
        {
            A = anchor.transform.position;
        }
    }
}
