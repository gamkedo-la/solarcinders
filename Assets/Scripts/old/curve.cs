using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curve : MonoBehaviour
{

    public int state = 1;

    public float timer = 2.0f;

    Vector3 temp = new Vector3(0, 0, 0);

    public int speed;
    float angleSpeed = -0.63f;

    // Start is called before the first frame update
    void Start()
    {

        temp = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (state == 1)
        {

            temp.z -= speed * Time.fixedDeltaTime;
            transform.position = temp;

        }

        if (state == 2)
        {

            transform.Rotate(0, 0, angleSpeed);

            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);

            }

        }
        
    }

   public void StateChange()
    {

        state = 2;

    }
}
