using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public float SpeedOne;

    public float SpeedTwo;
    public float SpeedTwoV;

    public float SpeedThree;
    public float SpeedThreeV;

    public float speedIntro;

    Vector3 temp;

    
    BossCenter C;
    BossArm A;

    public GameObject Explosion;
    public AudioSource explodeSFX;

    public Vector3 EndPoint = new Vector3(0, 10, 50);

    float dist;
    public float POW = 1.1f;
    public float mod = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

        C = transform.Find("center").gameObject.GetComponent<BossCenter>();
        A = transform.Find("ArmModelContainer").gameObject.GetComponent<BossArm>();

    }

    // Update is called once per frame
    void Update()
    {

        if(C.state == 0)
        {


            dist = Vector3.Distance(EndPoint, gameObject.transform.position);

            speedIntro = Mathf.Pow(dist, POW) + mod;

            float step = speedIntro * Time.deltaTime;

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, EndPoint, step);

            if (dist < .1)
            {

                if(transform.position.y > 0)
                {

                    EndPoint = transform.position;
                    EndPoint.y = -0.5f;

                }
                else
                {

                    C.state = 1;
                    A.state = 1;
                    A.spinning = true;


                }

            }






        }

        if(C.state == 1)
        {
            temp = transform.position;

            if (Mathf.Abs(temp.x) > 6)
            {

                SpeedOne *= -1;

                temp.x = Mathf.Clamp(temp.x, -5.9f, 5.9f);
            }

            temp.x += (SpeedOne * Time.deltaTime);
            transform.position = temp;
      
        }

        if (C.state == 2)
        {

            temp = transform.position;

            if (Mathf.Abs(temp.x) > 7)
            {

                SpeedTwo *= -1;

                temp.x = Mathf.Clamp(temp.x, -7, 7);
            }

            temp.x += (SpeedTwo * Time.deltaTime);

            

            if (Mathf.Abs(temp.y) > 2)
            {

                SpeedTwoV *= -1;

                temp.y = Mathf.Clamp(temp.y, -2, 2);
            }

            temp.y += (SpeedTwoV * Time.deltaTime);


            transform.position = temp;

        }

        if (C.state == 3)
        {

            temp = transform.position;

            if (Mathf.Abs(temp.x) > 8)
            {

                SpeedThree *= -1;

                temp.x = Mathf.Clamp(temp.x, -8, 8);
            }

            temp.x += (SpeedThree * Time.deltaTime);



            if (Mathf.Abs(temp.y) > 4)
            {

                SpeedThreeV *= -1;

                temp.y = Mathf.Clamp(temp.y, -4, 4);
            }

            temp.y += (SpeedThreeV * Time.deltaTime);


            transform.position = temp;

        }

        if(C.state == 4)
        {
            Death();

        }



    }

    public void Death()
    {
        Instantiate(Explosion, transform.position, transform.rotation);

        gameObject.transform.position = new Vector3(10000, 10000, 10000);

        GameObject player = GameObject.Find("Ship");
        player.GetComponent<Combo>().Add();
        GameObject.Find("EventManager").GetComponent<EventManager>().EndLevelList.Remove(gameObject);
        explodeSFX.Play();
        Destroy(gameObject);


    }


    

}
