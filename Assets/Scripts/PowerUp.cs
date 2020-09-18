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

    
    // Start is called before the first frame update
    void Start()
    {
        
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
            }

            statusBars.SetFill(Charge);
        }

        if (On == false && Input.GetButtonDown("Fire2") && Charge > 50)
        {
            On = true;

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
