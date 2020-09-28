using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int Health = 100;

    public StatusBars HP;

    public bool rolling = false;
    public float rolltimer;
    public float rolltimerReset;
    public float rollSpeed;

    int spin = 1;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1") &&
            GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().isPaused == false)
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

        if (Input.GetButtonDown("Fire3") && rolling == false &&
            GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().isPaused==false)
        {

            BarrellRoll();

        }

        // Pause:
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().TogglePause();
        }

        if (rolling == true)
        {
            
            transform.Rotate(transform.forward, rollSpeed*spin);
            spin++;
            rolltimer -= Time.deltaTime;

            if(rolltimer <= 0)
            {

                rolling = false;
                spin = 1;

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

        if (rolling == false)
        {
            Health -= dam;

            HP.SetFill(Health);
        }

    }

    void BarrellRoll()
    {

        rolling = true;
        rolltimer = rolltimerReset;

    }


}
