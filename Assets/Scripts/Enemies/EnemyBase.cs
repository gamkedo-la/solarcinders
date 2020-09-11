using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public Color StartingColor = new Color(1,1,1,1);
    public Color HitColor = new Color(1,0,0,0.5f);

    public float HitRegTimer = 0.3f;
    public float HitRegTimerReset = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<Renderer>().material.color == HitColor)
        {


            HitRegTimer -= Time.fixedDeltaTime;

            if (HitRegTimer <= 0)
            {

                HitRegTimer = HitRegTimerReset;
                gameObject.GetComponent<Renderer>().material.color = StartingColor;
            }



        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "PlayerLaser")
        {
            Debug.Log("enemyhit");
            //Destroy(gameObject);
            gameObject.GetComponent<Renderer>().material.color = HitColor;


        }

    }
}
