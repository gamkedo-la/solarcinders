using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapons : MonoBehaviour
{
    BossCenter C;

    public AudioSource shootingSFX;

    public GameObject laser;
    public GameObject bomb;
    public GameObject homingMissile;

    public Transform LaserGun;

    public float ShotTimerL;
    float ShotTimerB;
    float ShotTimerHM;

    public float ResetL;
    float ResetB;
    float ResetHM;

    // Start is called before the first frame update
    void Start()
    {

        C = transform.Find("center").gameObject.GetComponent<BossCenter>();

        ResetL = 1.5f;
        ShotTimerL = 2.5f;

        ResetHM = 1.0f;
        ShotTimerHM = 1.2f;

        ResetB = 1.0f;
        ShotTimerB = 1.2f;

    }

    // Update is called once per frame
    void Update()
    {

        if(C.state == 1)
        {

            

            ShotTimerL -= Time.deltaTime;

            if (ShotTimerL <= 0)
            {

                GameObject thisLaser = (GameObject)Instantiate(
                        laser,
                        LaserGun.position,
                        LaserGun.rotation);
                shootingSFX.Play();

                ShotTimerL = ResetL;

            }


        }

        if(C.state == 2)
        {

            ShotTimerHM -= Time.deltaTime;

            if (ShotTimerHM <= 0)
            {

                GameObject missile = (GameObject)Instantiate(
                        homingMissile,
                        LaserGun.position,
                        LaserGun.rotation);
                shootingSFX.Play();

                ShotTimerHM = ResetHM;

            }


        }

        if (C.state == 3)
        {

            ShotTimerB -= Time.deltaTime;

            if (ShotTimerB <= 0)
            {

                GameObject missile = (GameObject)Instantiate(
                        bomb,
                        LaserGun.position,
                        LaserGun.rotation);
                shootingSFX.Play();

                ShotTimerB = ResetHM;

            }


        }


    }
}
