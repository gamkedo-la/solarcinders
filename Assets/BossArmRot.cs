using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArmRot : MonoBehaviour
{


    public bool spinning = true;

    public float t = 0;

    public float lstart;

    public float lend;

    public float zt;

    public float Adist;

    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (spinning == true)
        {

            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        if (spinning == false)
        {

            zt = Mathf.Lerp(lstart, lend, t);

            t += Mathf.Abs(Time.deltaTime / (Adist / speed));

            Vector3 tmp = transform.rotation.eulerAngles;

            tmp.z = zt;

            transform.eulerAngles = tmp;

        }

    }

    public void NextPhase()
    {


        speed *= -1.2f;

        lstart = transform.rotation.eulerAngles.z;
        spinning = false;

        
        t = 0;
        //    if(transform.rotation.z > 180)
        //   {
        //       lend = 360.0f;
        //       Adist = 360 - transform.rotation.z;

        //  }
        //  else
        //  {
        lend = 180;
        Adist = transform.rotation.eulerAngles.z;
        //}

    }

}
