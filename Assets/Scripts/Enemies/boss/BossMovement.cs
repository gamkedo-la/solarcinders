using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public float SpeedOne;

    public float SpeedTwo;
    public float SpeedTwoV;

    public float SpeedThree;
    public float SpeedThreeV;

    Vector3 temp;

    
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
            temp = transform.position;

            if (Mathf.Abs(temp.x) > 6)
            {

                SpeedOne *= -1;

                temp.x = Mathf.Clamp(temp.x, -5.9f, 5.9f);
            }

            temp.x += (SpeedOne * Time.deltaTime);
            transform.position = temp;
      
        }

        if (C.state == 2)
        {

            temp = transform.position;

            if (Mathf.Abs(temp.x) > 7)
            {

                SpeedTwo *= -1;

                temp.x = Mathf.Clamp(temp.x, -7, 7);
            }

            temp.x += (SpeedTwo * Time.deltaTime);

            

            if (Mathf.Abs(temp.y) > 2)
            {

                SpeedTwoV *= -1;

                temp.y = Mathf.Clamp(temp.y, -2, 2);
            }

            temp.y += (SpeedTwoV * Time.deltaTime);


            transform.position = temp;

        }

        if (C.state == 3)
        {

            temp = transform.position;

            if (Mathf.Abs(temp.x) > 8)
            {

                SpeedThree *= -1;

                temp.x = Mathf.Clamp(temp.x, -8, 8);
            }

            temp.x += (SpeedThree * Time.deltaTime);



            if (Mathf.Abs(temp.y) > 4)
            {

                SpeedThreeV *= -1;

                temp.y = Mathf.Clamp(temp.y, -4, 4);
            }

            temp.y += (SpeedThreeV * Time.deltaTime);


            transform.position = temp;

        }

        if(C.state == 4)
        {
            Death();

        }



    }

    public void Death()
    {

        Destroy(gameObject);


    }


    

}
