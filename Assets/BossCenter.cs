using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCenter : MonoBehaviour
{

    public GameObject target;

    public bool invuln = true;

    public int Health;

    public int state = 1;

    BossArm BA;

    BossArmRot R;

    GameObject player;

    public GameObject centerlight;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Ship");

        BA = GameObject.Find("ArmModelContainer").GetComponent<BossArm>();
        R = GameObject.Find("Arm").GetComponent<BossArmRot>();

        player = GameObject.Find("Ship");

        centerlight = transform.Find("Sphere").gameObject;



        Health = 50;
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            transform.LookAt(target.transform);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PlayerLaser" && invuln == false)
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
        invuln = true;
        centerlight.SetActive(false);

        if (state < 4)
        {
            Health = ((state * 20) + 30);
            BA.stateTimer = 3.0f;
            BA.spinning = true;
            BA.GunLight.SetActive(true);
            R.spinning = true;
            player.GetComponent<PowerUp>().Add(GetComponent<Charge>().charge);

        }

    }

}
