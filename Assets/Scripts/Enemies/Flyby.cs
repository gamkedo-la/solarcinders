using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyby : MonoBehaviour
{

    public enum RL { right, left};
    public enum TB { bot, mid, top};

    public RL StartSide;

    public TB tB;

    public int Sw;

    Vector3 SpawnPos = new Vector3(50, 0, 50);

    Vector3 Temp = new Vector3(0, 0, 0);

    public float speed;
    float step;

    int state = 1;

    public int Health;
    public int PointsGiven;

    GameObject Gun;

    public float shotTimer;
    public float Reset;

   

    // Start is called before the first frame update
    void Start()
    {
        
        if (StartSide == RL.left)
        {

            Sw = 1;
        }
        else if (StartSide == RL.right)
        {
            Sw = -1;

        }

        if(tB == TB.top)
        {

            SpawnPos.y += 7;

        }

        if (tB == TB.bot)
        {

            SpawnPos.y -= 7;

        }

        SpawnPos.x *= Sw;
        transform.position = SpawnPos;
        state = 1;

        Gun = transform.Find("Gun").gameObject;
        Gun.GetComponent<LookAt>().target = (GameObject.Find("Ship"));

    }

    // Update is called once per frame
    void Update()
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


        if(Health <= 0)
        {



        }
    }

    void Despawn()
    {

        Destroy(gameObject);

    }

    void Death()
    {

        Destroy(gameObject);
        GameObject player = GameObject.Find("Ship");
        player.GetComponent<Combo>().Add();
        player.GetComponent<Score>().ScoreChange(PointsGiven);

    }


}
