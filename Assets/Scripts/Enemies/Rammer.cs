using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rammer : MonoBehaviour
{
    GameObject player;
    public float speed = 1.0f;
    float timer = 2;
    public float dist = 1050.0f;
    int state = 1;
    //Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");
    }

    // Update is called once per frame
    void Update()
    {

        if (state == 1)
        {
            dist -= speed * Time.fixedDeltaTime;
            transform.position += transform.forward * speed * Time.fixedDeltaTime;

            if (dist <= 0)
            {
               // temp = transform.position;
               // temp.z = 1100 - dist;
               // transform.position = temp;
                state = 2;
            }
        }
        if (state ==2)
        {

            transform.LookAt(player.transform);
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                dist = 1000.0f;
                speed = 50;
                state = 1;
            }

        }

    }

    void Death()
    {

        Destroy(gameObject);

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "PlayerLaser")
        {

            Death();

        }

    }
}
