using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    GameObject player;
    public float speed;
    float timer = 2;
    int state = 1;
    public int HP = 1;

    public GameObject waypoint;

    public float POW;
    public float mod;

    //Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");
    }

    // Update is called once per frame
    void Update()
    {

        if (HP <= 0)
        {
            Death();
        }

        if (state == 1)
        {

            float dist = Vector3.Distance(waypoint.transform.position, gameObject.transform.position);

            speed = Mathf.Pow(dist, POW) + mod;

            float step = speed * Time.deltaTime;

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, waypoint.transform.position, step);

            if(dist < .05)
            {
                state = 2;

            }

        }
        if (state == 2)
        {

            transform.LookAt(player.transform);
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {

                gameObject.GetComponent<Shoot>().Fire();
                timer = 2;

            }

        }

    }
    void Death()
    {

        Destroy(gameObject);
        //update score

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

}
