using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{

    public int Health = 100;

    public StatusBars HP;
    public AudioSource warningSFX;
    public AudioSource engine;
    public AudioSource playerHitSFX;

    public bool rolling = false;
    public float rolltimer;
    public float rolltimerReset;
    public float rollSpeed;

    int spin = 1;

    GameObject model;

    public GameObject crosshairFar;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LowHealthChecker());

        model = transform.Find("ShipContainer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        //if (Input.GetButtonDown("Fire1") &&
        //    GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().isPaused == false)
        //{
        //    if (GetComponent<PowerUp>().On == true)
        //    {
        //        GetComponent<Shoot>().PowerShot();

        //    }
        //    else
        //    {
        //        GetComponent<Shoot>().Fire();
        //    }
        //}

        //if (Input.GetButtonDown("Fire3") && rolling == false &&
        //    GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().isPaused == false)
        //{

        //    BarrellRoll();

        //}

        // Pause:
        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().TogglePause();
        //}

        if (crosshairFar != null && rolling == false)
        {
            model.transform.LookAt(crosshairFar.transform);
        }
        

        if (rolling == true)
        {

            model.transform.Rotate(transform.forward, rollSpeed * Time.deltaTime);
            spin++;
            rolltimer -= Time.deltaTime;

            if(rolltimer <= 0)
            {

                rolling = false;
                spin = 1;
                

            }

        }

        if(rolling == false && engine.pitch > 1)
        {

            engine.pitch -= Time.deltaTime;

            


            if(engine.pitch < 1)
            {

                engine.pitch = 1;
            }

        }




        if(Health <= 0){

            //Active gameover
            GameObject.FindGameObjectWithTag("GameoverMenu").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.FindGameObjectWithTag("GameoverMenu").GetComponent<CanvasGroup>().blocksRaycasts = true;

            Destroy(gameObject);
        }

    }

    IEnumerator LowHealthChecker()
    {
        while(true)
        {
            if(Health <=25)
            {
                warningSFX.Play();
                yield return new WaitForSeconds(warningSFX.clip.length+0.2f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void OnCollisionEnter(Collision collide)
    {
        TakeDamage(collide.gameObject.GetComponent<Damage>().damage);
        playerHitSFX.Play();
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
        engine.pitch = 1.4f;

    }

    private void OnBarrelRoll()
    {
        Debug.Log("Barrel roll pressed");
        if (rolling == false && GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().isPaused == false)
        {
            BarrellRoll();
        }
    }

    private void OnShoot()
    {
        Debug.Log("Shoot pressed");
        if (GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().isPaused == false)
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
    }

    private void OnPause()
    {
        Debug.Log("Pause pressed");
        GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().TogglePause();
    }
}
