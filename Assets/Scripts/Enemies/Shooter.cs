using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    GameObject player;
    public float speed = 1.0f;
    float timer = 2;
    public float dist = 1050.0f;
    int state = 1;
    public int HP = 1;
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
            dist -= speed * Time.fixedDeltaTime;
            transform.position += transform.forward * speed * Time.fixedDeltaTime;

            if (dist <= 0)
            {
                transform.LookAt(player.transform);
                gameObject.GetComponent<Shoot>().Fire();
                state = 2; }
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

            HP -= 20;
            

        }

    }
}
