using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int Health = 100;

    public StatusBars statusBars;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1"))
        {
            if (GetComponent<PowerUp>().On == true)
            {
                GetComponent<Shoot>().PowerShot();

            }
            else
            {
                GetComponent<Shoot>().Fire();
            }
        }

        if(Health <= 0){

            //Active gameover
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision collide)
    {
        TakeDamage(collide.gameObject.GetComponent<Damage>().damage);
    }

    void TakeDamage(int dam)
    {
        Health -= dam;

        statusBars.SetFill(Health);


    }


}
