using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float timer;
    public float speed;
    float step;

    public GameObject Explosion;

    // Use this for initialization
    void Start()
    {

        Destroy(gameObject, timer);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = gameObject.transform.position;
        temp += gameObject.transform.forward * speed * Time.deltaTime;
        gameObject.transform.position = temp;
    
    }

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            // Debug.Log("hit");

            Quaternion quaternion = transform.rotation;
            quaternion.eulerAngles = new Vector3(quaternion.eulerAngles.x, quaternion.eulerAngles.y + 180, quaternion.eulerAngles.z);

            Instantiate(Explosion, transform.position, quaternion);
            Destroy(gameObject);
        }
    }
}
