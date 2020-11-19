using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{

    public float speed;

    GameObject player;

    public int state = 1;

    int HP = 1;

    float dist;

    public AudioSource explodeSFX;

    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");

        GetComponent<LookAt>().target = player;
        StartCoroutine(CheckDeathLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            state = 2;
        }

        if (state == 1)
        {
            float step = speed * Time.deltaTime;

            if (player != null)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, step);
            }

            dist = Vector3.Distance(player.transform.position, gameObject.transform.position);

            if (dist < 10)
            {
                state = 2;
                GetComponent<LookAt>().target = null;

            }
        }
        if (state == 2)
        {

            Vector3 temp = gameObject.transform.position;
            temp += gameObject.transform.forward * speed * Time.deltaTime;
            gameObject.transform.position = temp;

        }
        if(transform.position.z < 0)
        {

            Despawn();
        }


    }

    IEnumerator CheckDeathLoop()
    {
        while (true)
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
        Quaternion quaternion = transform.rotation;
        quaternion.eulerAngles = new Vector3(quaternion.eulerAngles.x, quaternion.eulerAngles.y + 180, quaternion.eulerAngles.z);

        Instantiate(Explosion, transform.position, quaternion);
        gameObject.transform.position = new Vector3(10000, 10000, 10000);
        explodeSFX.Play();

    }

    void Despawn()
    {

        Destroy(gameObject);
    }

    void TakeDamage(int dam)
    {

        HP -= dam;

    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("hit homing missile");

        if (collision.gameObject.tag == "PlayerLaser")
        {

            TakeDamage(collision.gameObject.GetComponent<Damage>().damage);


        }

        if(collision.gameObject.tag == "Player")
        {

            TakeDamage(10);
        }

    }


}
