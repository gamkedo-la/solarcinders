using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour
{

    GameObject player;
    float speed;

    public enum LRC { left, right, center };

    public LRC thisLRC;

    float ShotTimer = 0.5f;
    float ShotReset = 1.5f;

    public int state = 1;
    public int HP = 50;

    public int PointsGiven = 80;

    public float POW;
    public float mod;
    public float dist;

    public AudioSource explodeSFX;

    public AudioSource shootSFX;

    public AudioSource getHitSFX;

    int i = 0;

    Transform LeftLauncher;
    Transform RightLauncher;
    int side = 1;

    public GameObject Missile;

    public GameObject Explosion;

    Vector3 EndPoint = new Vector3(0,0,70);
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");

        if (thisLRC == LRC.left)
        {

            EndPoint.x -= 20;

        }
        if (thisLRC == LRC.right)
        {

            EndPoint.x += 20;

        }

        LeftLauncher = transform.Find("LeftLauncher");
        RightLauncher = transform.Find("RightLauncher");

        StartCoroutine(CheckDeathLoop());


    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyBase>().Active == true)
        {




            if (state == 1)
            {

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

                if (ShotTimer <= 0)
                {
                    if (side == 1)
                    {

                        shootSFX.Play();

                        Instantiate(Missile, LeftLauncher.position, Quaternion.identity);
                        side *= -1;

                        ShotTimer = ShotReset;
                        return;
                    }
                    if (side == -1)
                    {

                        shootSFX.Play();
                        Instantiate(Missile, RightLauncher.position, Quaternion.identity);
                        side *= -1;

                        ShotTimer = ShotReset;
                        return;
                    }



                }
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

    void TakeDamage(int dam)
    {
        getHitSFX.Play();
        HP -= dam;

    }

    void OnCollisionEnter(Collision collision)
    {



        if (collision.collider.tag == "PlayerLaser")
        {

            TakeDamage(collision.gameObject.GetComponent<Damage>().damage);


        }

    }
}
