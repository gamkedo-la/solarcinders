using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUp : MonoBehaviour
{

    public float Charge = 0;
    public bool On = false;
    public int drainRate;

    public bool DebugStartWithFullCharge = false;

    public StatusBars statusBars;

    public Material wing_N;
    public Material engine_N;

    public Material wing_P;
    public Material engine_P;

    public GameObject model;
    public GameObject engine;

    public AudioSource powerUpSFX;
    public AudioSource powerUpDepletedSFX;
    public AudioSource PowerUpActivateSFX;

    MeshRenderer rend;

    bool ready = false;
   

    
    // Start is called before the first frame update
    void Start()
    {

        rend = model.GetComponent<MeshRenderer>();
        


        if(DebugStartWithFullCharge == true)
        {
            Charge = 100;

        }

    }

    // Update is called once per frame
    void Update()
    {
        

        if (On == true)
        {

            Charge -= Time.deltaTime * drainRate;


            if (Charge <= 0)
            {
                Charge = 0;
                On = false;
                var tempmaterialarray = rend.materials;
                tempmaterialarray[0] = wing_N;
                tempmaterialarray[3] = engine_N;
                rend.materials = tempmaterialarray;
                ready = false;

                /* rend.materials[0] = wing_N;
                rend.materials[3] = engine_N; */

                powerUpDepletedSFX.Play();
            }

            statusBars.SetFill(Charge);
        }

        //if (On == false && Input.GetButtonDown("Fire2") && Charge >= 50)
        //{
        //    On = true;
        //    var tempmaterialarray = rend.materials;
        //    tempmaterialarray[0] = wing_P;
        //    tempmaterialarray[3] = engine_P;
        //    rend.materials = tempmaterialarray;
        //    /* rend.materials[0] = wing_P;
        //    rend.materials[3] = engine_P; */

        //}


    }

    public void Add(float i)
    {

        Charge += i;

        if (Charge > 100)
        {
            Charge = 100;
            

        }
        if (Charge >= 50 && ready == false)
        {
            powerUpSFX.Play();
            ready = true;
        }

        statusBars.SetFill(Charge);

    }

    private void OnPowerup()
    {
        Debug.Log("Powerup pressed");
        if (On == false && Charge >= 50)
        {
            PowerUpActivateSFX.Play();
            On = true;
            var tempmaterialarray = rend.materials;
            tempmaterialarray[0] = wing_P;
            tempmaterialarray[3] = engine_P;
            rend.materials = tempmaterialarray;
            /* rend.materials[0] = wing_P;
            rend.materials[3] = engine_P; */

        }
    }

}
