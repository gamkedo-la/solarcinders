using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArm : MonoBehaviour
{
    

    //GameObject BL;

    public bool laser = false;

    public int Health;

    int state = 1;

    public float stateTimer;

    BossCenter C;

    bool invuln = false;

    public bool spinning = true;

    BossArmRot R;

    GameObject player;

    public GameObject GunLight;

    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        // BL = transform.Find("big laser").gameObject;

        C = GameObject.Find("center").GetComponent<BossCenter>();
        R = GameObject.Find("Arm").GetComponent<BossArmRot>();
        GunLight = transform.Find("Sphere").gameObject;
        model = transform.Find("model").gameObject;

        player = GameObject.Find("Ship");

        Health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        


        if(stateTimer > 0)
        {
            stateTimer -= Time.deltaTime;

            if(stateTimer <= 0)
            {

                invuln = false;
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PlayerLaser" && invuln == false && laser == false)
        {

            TakeDamage(collision.gameObject.GetComponent<Damage>().damage);
        }
    }

    private void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            StateMachine();
        }
    }


    void StateMachine()
    {

        state++;
        C.invuln = false;
        invuln = true;
        R.NextPhase();
        spinning = false;
        GunLight.SetActive(false);

        
        if (state < 4)
        {
            Health = ((10 * state) + 20);
            player.GetComponent<PowerUp>().Add(GetComponent<Charge>().charge);
        }
    }

}
