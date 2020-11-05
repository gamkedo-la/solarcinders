using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rammer : MonoBehaviour
{
    GameObject player;
    public float speed;


    float ShotTimer = 0.5f;
    float ShotReset = 2.0f;


    public int state = 0;
    public int HP = 1;

    public int PointsGiven = 10;

    public Transform waypoint;

    public float POW;
    public float mod;
    public float dist = 0;

    public AudioSource explodeSFX;

    int Seed;

    public GameObject Explosion;

    Vector3 EndPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");

        Seed = (int)GetComponent<EnemyBase>().SpawnTime;


        if (waypoint == null)
        {
            FlightPath();


        }

        EndPoint = waypoint.position;


        StartCoroutine(CheckDeathLoop());
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<EnemyBase>().Active == true)
        {

            

            


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


                if (player != null && ShotTimer > 0)
                {
                    transform.LookAt(player.transform);
                }
                if (ShotTimer <= 0)
                {
                    speed = 50;
                    Vector3 temp = gameObject.transform.position;
                    temp += gameObject.transform.forward * speed * Time.deltaTime;
                    gameObject.transform.position = temp;

                }



            }

            if (transform.position.z < 0)
            {

                Despawn();
            }
        }

    }

    void WakeUp()
    {
        EndPoint = waypoint.position;
        state = 1;


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
        if(player!=null)
        {
            player.GetComponent<Combo>().Add();
            player.GetComponent<Score>().ScoreChange(PointsGiven);
            player.GetComponent<PowerUp>().Add(GetComponent<Charge>().charge);
        }
        GameObject.Find("EventManager").GetComponent<EventManager>().EndLevelList.Remove(gameObject);
        explodeSFX.Play();

    }

    void Despawn()
    {
        GameObject.Find("EventManager").GetComponent<EventManager>().EndLevelList.Remove(gameObject);
        Destroy(gameObject);
    }



    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("hit Shooter");

        if (collision.collider.tag == "PlayerLaser")
        {

            TakeDamage(collision.gameObject.GetComponent<Damage>().damage);


        }

        if (collision.collider.tag == "Player")
        {
            Quaternion quaternion = transform.rotation;
            quaternion.eulerAngles = new Vector3(quaternion.eulerAngles.x, quaternion.eulerAngles.y + 180, quaternion.eulerAngles.z);

            Instantiate(Explosion, transform.position, quaternion);

            TakeDamage(10);
        }

    }

    void TakeDamage(int dam)
    {

        HP -= dam;

    }

    void FlightPath()
    {

        if (Seed % 4 == 0)
        {

            waypoint = GameObject.Find("WP (0)").transform;
            
        }
        if (Seed % 4 == 1)
        {

            waypoint = GameObject.Find("WP (1)").transform;
            

        }
        if (Seed % 4 == 2)
        {

            waypoint = GameObject.Find("WP (2)").transform;
           

        }
        if (Seed % 4 == 3)
        {

            waypoint = GameObject.Find("WP (3)").transform;
           

        }

    }
}
