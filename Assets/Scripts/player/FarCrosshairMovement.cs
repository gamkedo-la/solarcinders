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
    void FixedUpdate()
    {

        T = target.transform.position;
        if (anchor != null)
        {
            A = anchor.transform.position;
        }

        Vector3 GoToPos;

        if (Mathf.Abs(Input.GetAxis("Vertical")) <= 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) <= 0.2f)
        {
            GoToPos = A;

        }
        else
        {
            GoToPos = T;

        }

        float dist = Vector3.Distance(GoToPos, transform.position);

        
            speed = Mathf.Pow(dist, POW) + mod;

            step = speed * Time.deltaTime;

        

        if (Vector3.Distance(transform.position, GoToPos) <= step)
        {
            transform.position = GoToPos;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, GoToPos, step);
        }

        
    }
}
