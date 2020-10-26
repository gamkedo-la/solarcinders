using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public float SpeedOne;
    public float SpeedTwo;
    public float SpeedThree;

    
    BossCenter C;

    // Start is called before the first frame update
    void Start()
    {

        C = transform.Find("center").gameObject.GetComponent<BossCenter>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(C.state == 1)
        {




        }



        
    }


    

}
