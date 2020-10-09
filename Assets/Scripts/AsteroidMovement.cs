using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float timer = 2.0f;

    public AudioSource explodeSFX;

    public int HP = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckDeathLoop());

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyBase>().Active == true)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
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
        gameObject.transform.position = new Vector3(10000, 10000, 10000);

        GameObject player = GameObject.Find("Ship");
        player.GetComponent<Combo>().Add();
       
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
}
