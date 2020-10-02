﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyby : MonoBehaviour
{

    //public enum RL { right, left};
    //public enum TB { bot, mid, top};

    //public RL StartSide;

    //public TB tB;

    public int Sw;

    //Vector3 SpawnPos = new Vector3(50, 0, 50);

    Vector3 Temp = new Vector3(0, 0, 0);

    public float speed;
    float step;

    int state = 0;

    public int Health;
    public int PointsGiven;

    GameObject Gun;

    public float shotTimer;
    public float Reset;

    public AudioSource explodeSFX;


    // Start is called before the first frame update
    void Start()
    {
        
        if (transform.position.x < 0)
        {

            Sw = 1;
        }
        else if (transform.position.x > 0)
        {
            Sw = -1;

        }

       /* if(tB == TB.top)
        {

            SpawnPos.y += 7;

        }

        if (tB == TB.bot)
        {

            SpawnPos.y -= 7;

        }

        SpawnPos.x *= Sw;
        transform.position = SpawnPos;*/


        state = 1;

        Gun = transform.Find("Gun").gameObject;
        Gun.GetComponent<LookAt>().target = (GameObject.Find("Ship"));
        StartCoroutine(CheckDeathLoop());

    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<EnemyBase>().Active == true)
        {
            
            step = speed * Time.deltaTime;

            Temp = transform.position;
            Temp.x -= step * Sw;

            transform.position = Temp;

            if (Mathf.Abs(transform.position.x) > 50)
            {

                Sw *= -1;

                Temp = transform.position;
                Temp.z -= 8;
                transform.position = Temp;

                state++;

            }

            if (state > 3)
            {

                Despawn();

            }

            shotTimer -= Time.deltaTime;

            if (shotTimer <= 0)
            {

                Gun.GetComponent<Shoot>().Fire();

                shotTimer = Reset;

            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "PlayerLaser")
        {

            TakeDamage(collision.gameObject.GetComponent<Damage>().damage);


        }

    }

    void TakeDamage(int dam)
    {

        Health -= dam;

    }

    void Despawn()
    {

        Destroy(gameObject);

    }

    IEnumerator CheckDeathLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (Health <= 0)
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


}
