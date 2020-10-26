using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBigLaser : MonoBehaviour
{

    public float speed;
    Vector3 temp;
    public GameObject laser;
    BossArm A;

    bool firing = false;

    public float t;
    public float k;

    public float testTime = 3.0f;



    // Start is called before the first frame update
    void Start()
    {

        A = GameObject.Find("ArmModelContainer").GetComponent<BossArm>();
        laser.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (A.spinning == true)
        {

            testTime -= Time.deltaTime;

            if (testTime <= 0 && firing == false)
            {
                Fire();
                testTime = 6;

            }


            if (firing == true)
            {
                k = Mathf.Lerp(1, 60, t);
                t += Time.deltaTime;

                temp.z = k;
                transform.localScale = temp;

                if (t >= 2.5f)
                {
                    firing = false;
                    laser.SetActive(false);
                    A.laser = false;

                }
            }
        }
    }

    void Fire()
    {
        firing = true;

        laser.SetActive(true);
        A.laser = true;
        temp = transform.localScale;
        t = 0;


    }


}
