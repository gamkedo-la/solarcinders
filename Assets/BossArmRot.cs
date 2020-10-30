using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArmRot : MonoBehaviour
{


    public bool spinning = true;

    float t = 0;

    float tt = 0;

    float lstart;

    float lend;

    float zt;

    float xt;

    float Adist;

    public float speed;

    public GameObject model;

    

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

            xt = Mathf.Lerp(35.0f, 0.0f, tt);

            tt += Time.deltaTime * 10;

            Vector3 Q = transform.rotation.eulerAngles;

            Q.x = xt;

            model.transform.eulerAngles = Q;

        }
        if (spinning == false)
        {

            zt = Mathf.Lerp(lstart, lend, t);

            t += Mathf.Abs(Time.deltaTime / (Adist / speed));

            Vector3 tmp = transform.rotation.eulerAngles;

            tmp.z = zt;

            transform.eulerAngles = tmp;

            if(t >= 1)
            {

                xt = Mathf.Lerp(0.0f, 35.0f, tt);

                tt += Time.deltaTime * 4;

                Vector3 Q = transform.rotation.eulerAngles;

                Q.x = xt;

                model.transform.eulerAngles = Q;


            }


        }

    }

    public void NextPhase()
    {


        speed *= -1.2f;

        lstart = transform.rotation.eulerAngles.z;
        spinning = false;

        
        t = 0;
        tt = 0;
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
