using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    MeshRenderer rend;

    
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

                rend.materials[0] = wing_N;
                rend.materials[3] = engine_N;
            }

            statusBars.SetFill(Charge);
        }

        if (On == false && Input.GetButtonDown("Fire2") && Charge > 50)
        {
            On = true;

            rend.materials[0] = wing_P;
            rend.materials[3] = engine_P;

        }


    }

    public void Add(float i)
    {

        Charge += i;

        if (Charge > 100)
        {
            Charge = 100;
        }

        statusBars.SetFill(Charge);

    }

}
