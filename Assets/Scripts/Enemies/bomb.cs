using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float speed;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if(transform.position.z < 23)
        {
            Explode();

        }


    }

    void Explode()
    {
        GameObject exp = (GameObject)Instantiate(
                        explosion,
                        transform.position,
                        transform.rotation);
        //shootingSFX.Play();
        Destroy(gameObject);

    }
}
