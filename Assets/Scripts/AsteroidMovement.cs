using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 1.0f;




    

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyBase>().Active == true)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if(transform.position.z < 0)
        {

            Despawn();
        }
    }

    

    void Despawn()
    {
        GameObject.Find("EventManager").GetComponent<EventManager>().EndLevelList.Remove(gameObject);
        Destroy(gameObject);
    }

    

    
}
