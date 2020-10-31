using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneIntro : MonoBehaviour
{

    public GameObject[] lights;

    public float lightTimer;
    public float lightReset;

    public float t;

    public float y;

    public float tt;

    Vector3 temp = new Vector3(0, 0, 0);

    float speed;

    int LT = 0;


    // Start is called before the first frame update
    void Start()
    {

        temp = transform.position;

        y = temp.y;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (t <= 1)
        {
            temp.y = Mathf.Lerp(0, -2, t);
            t += Time.deltaTime;

            transform.position = temp;
        }
        if (t > 1)
        {

            speed = Mathf.Lerp(0, 600, tt);

            tt += (Time.deltaTime / 5);

            temp.z -= speed * Time.deltaTime;

            transform.position = temp;


        }

        lightTimer -= Time.deltaTime;

        if(lightTimer <= 0 && LT < 5)
        {
            lights[LT].SetActive(true);
            LT++;

            lightReset *= 0.84f ;
            lightTimer = lightReset;
            

        }

        if(transform.position.z < -200)
        {

            Destroy(gameObject);
        }




    }
}
