﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    GameObject player;
    public float speed;


    float ShotTimer = 0.5f;
    float ShotReset = 2.0f;

    float StateTimer = 5.0f;
    float StateReset = 5.0f;


    public int state = 1;
    public int HP = 1;

    public int PointsGiven = 10;

    public Transform[] waypoints;

    public float POW;
    public float mod;
    public float dist;

    public AudioSource explodeSFX;

    int Seed;

    int i = 0;

    public Vector3 EndPoint = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");

        Seed = (int)GetComponent<EnemyBase>().SpawnTime;

        i = 0;

        

        //FlightPath();

        
        StartCoroutine(CheckDeathLoop());
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<EnemyBase>().Active == true)
        {
            if(waypoints[0] == null)
            {
                FlightPath();
                


            }
            if(EndPoint.z == 0)
            {

                EndPoint = waypoints[i].position;

            }


            if (state == 1)
            {
                if (player != null)
                {
                    transform.LookAt(player.transform);
                }

                dist = Vector3.Distance(EndPoint, gameObject.transform.position);

                speed = Mathf.Pow(dist, POW) + mod;

                float step = speed * Time.deltaTime;

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, EndPoint, step);

                if (dist < .1)
                {
                    state = 2;

                }

            }
            if (state == 2)
            {
                ShotTimer -= Time.deltaTime;
                StateTimer -= Time.deltaTime;

                if (player != null)
                {
                    transform.LookAt(player.transform);
                }


                if (ShotTimer <= 0)
                {

                    gameObject.GetComponent<Shoot>().Fire();
                    ShotTimer = ShotReset;

                }
                if (StateTimer <= 0 && i >= waypoints.Length)
                {

                    state = 3;
                    return;

                }
                else if (StateTimer <= 0)
                {
                    i++;
                    state = 1;
                    StateTimer = StateReset;
                    ShotTimer = ShotReset;
                    EndPoint = waypoints[i].transform.position;

                }

            }
            if (state == 3)
            {

                gameObject.transform.rotation = Quaternion.identity;
                float step = mod * Time.deltaTime * 2;
                Vector3 temp = transform.position;
                temp.z -= step * 5;
                gameObject.transform.position = temp;


                if (gameObject.transform.position.z < -50)
                {
                    Despawn();

                }

            }
        }


    }

    void WakeUp()
    {
        EndPoint = waypoints[i].transform.position;
        state = 1;


    }

    IEnumerator CheckDeathLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            if (HP <= 0)
            {
                Death();

                // Wait for SFX before destroying:
                yield return new WaitForSeconds(explodeSFX.clip.length);
                Destroy(gameObject);
            }
        }
    }
    void Death()
    {
        // send to the void, away from the player:
        gameObject.transform.position = new Vector3(10000, 10000, 10000);

        GameObject player = GameObject.Find("Ship");
        player.GetComponent<Combo>().Add();
        player.GetComponent<Score>().ScoreChange(PointsGiven);
        player.GetComponent<PowerUp>().Add(GetComponent<Charge>().charge);
        explodeSFX.Play();

    }

    void Despawn()
    {

        Destroy(gameObject);
    }



    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("hit Shooter");

        if (collision.collider.tag == "PlayerLaser")
        {

            TakeDamage(collision.gameObject.GetComponent<Damage>().damage);
            

        }

    }

    void TakeDamage(int dam)
    {

        HP -= dam;

    }

    void FlightPath()
    {

        waypoints = new Transform[4];

        if (Seed % 4 == 0)
        {

            waypoints[0] = GameObject.Find("WP (0)").transform;
            waypoints[1] = GameObject.Find("WP (1)").transform;
            waypoints[2] = GameObject.Find("WP (2)").transform;
            waypoints[3] = GameObject.Find("WP (3)").transform;

        }
        if (Seed % 4 == 1)
        {

            waypoints[0] = GameObject.Find("WP (1)").transform;
            waypoints[1] = GameObject.Find("WP (2)").transform;
            waypoints[2] = GameObject.Find("WP (3)").transform;
            waypoints[3] = GameObject.Find("WP (0)").transform;

        }
        if (Seed % 4 == 2)
        {

            waypoints[0] = GameObject.Find("WP (2)").transform;
            waypoints[1] = GameObject.Find("WP (3)").transform;
            waypoints[2] = GameObject.Find("WP (0)").transform;
            waypoints[3] = GameObject.Find("WP (3)").transform;

        }
        if (Seed % 4 == 3)
        {

            waypoints[0] = GameObject.Find("WP (3)").transform;
            waypoints[1] = GameObject.Find("WP (0)").transform;
            waypoints[2] = GameObject.Find("WP (1)").transform;
            waypoints[3] = GameObject.Find("WP (2)").transform;

        }

    }

}
