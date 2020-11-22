using System.Collections;
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

    public int state = 0;

    public int Health;
    public int PointsGiven;

    GameObject Gun;

    public float shotTimer;
    public float Reset;

    public AudioSource explodeSFX;
    public GameObject Explosion;
    public AudioSource getHitSFX;

    GameObject player;

    bool ded = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");
        if (transform.position.x < 0)
        {

            Sw = -1;
        }
        else if (transform.position.x > 0)
        {
            Sw = 1;

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

            if (Mathf.Abs(transform.position.x) > 50 && ded == false)
            {

                Sw *= -1;

                Temp = transform.position;
                Temp.z -= 8;
                transform.position = Temp;
                transform.eulerAngles = new Vector3(0, 180 * state, 0);

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
        getHitSFX.Play();
        Health -= dam;

    }

    void Despawn()
    {
        GameObject.Find("EventManager").GetComponent<EventManager>().EndLevelList.Remove(gameObject);
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
        Instantiate(Explosion, transform.position, transform.rotation);
        ded = true;
        gameObject.transform.position = new Vector3(10000, 10000, 10000);
        player.GetComponent<Combo>().Add();
        player.GetComponent<Score>().ScoreChange(PointsGiven);
        player.GetComponent<PowerUp>().Add(GetComponent<Charge>().charge);
        GameObject.Find("EventManager").GetComponent<EventManager>().EndLevelList.Remove(gameObject);
        explodeSFX.Play();

    }


}
