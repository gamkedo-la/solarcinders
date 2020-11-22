using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber : MonoBehaviour
{

    GameObject crosshair;
    int state = 1;
    Vector3 EndPoint = new Vector3(0,0,0);
    public float speed;

    float dist;
    public float POW;
    public float mod;

    public float stateTimer;
    public float reset;

    public int HP;
    public int PointsGiven;

    public AudioSource explodeSFX;
    public AudioSource getHitSFX;

    levelBounds SceneMan;

    public GameObject Explosion;


    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.Find("CrosshairFar");
        EndPoint = crosshair.transform.position;

        StartCoroutine(CheckDeathLoop());

        SceneMan = GameObject.Find("SceneManager").GetComponent<levelBounds>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(state == 1)
        {

            dist = Vector3.Distance(EndPoint, gameObject.transform.position);

            speed = Mathf.Pow(dist, POW) + mod;

            float step = speed * Time.deltaTime;

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, EndPoint, step);

            if (dist < .1)
            {

                state = 2;
                stateTimer = reset; 
                return;

            }

        }
        if (state == 2)
        {
            stateTimer -= Time.deltaTime;
            if(stateTimer < 0)
            {

                GetComponent<Shoot>().Fire();
                stateTimer = reset;
                FlightPath();
                state = 1;

            }

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
        Instantiate(Explosion, transform.position, transform.rotation);

        gameObject.transform.position = new Vector3(10000, 10000, 10000);

        GameObject player = GameObject.Find("Ship");
        player.GetComponent<Combo>().Add();
        player.GetComponent<Score>().ScoreChange(PointsGiven);
        player.GetComponent<PowerUp>().Add(GetComponent<Charge>().charge);
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

    }

    void FlightPath()
    {

        EndPoint = crosshair.transform.position;
        EndPoint.x = Mathf.Clamp(EndPoint.x, -SceneMan.x, SceneMan.x);
        EndPoint.y = Mathf.Clamp(EndPoint.y, SceneMan.yMin, SceneMan.yMax);

    }

    void TakeDamage(int dam)
    {

        HP -= dam;
        getHitSFX.Play();
    }
}
