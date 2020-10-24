using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArmRot : MonoBehaviour
{


    public bool spinning = true;

    float t = 0;

    float lstart;

    float lend;

    float zt;

    float Adist;

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

            t += Time.deltaTime / (Adist / speed);

            Vector3 tmp = transform.rotation.eulerAngles;

            tmp.z = zt;

            transform.eulerAngles = tmp;

        }

    }

    public void NextPhase()
    {


        speed *= -1.2f;
        spinning = false;

        lstart = transform.rotation.z;
        t = 0;
        //    if(transform.rotation.z > 180)
        //   {
        //       lend = 360.0f;
        //       Adist = 360 - transform.rotation.z;

        //  }
        //  else
        //  {
        lend = 180;
        Adist = transform.rotation.z;
        //}

    }

}
