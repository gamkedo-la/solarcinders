using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 1.0f;
    public float timer = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeathOfALaser", timer);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.forward * speed * Time.deltaTime;

    }

    public void DeathOfALaser()
    {

        Destroy(gameObject);



    }

    private void OnCollisionEnter(Collision collision)
    {
        DeathOfALaser();
    }
}
