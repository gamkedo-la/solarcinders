using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour
{

    Vector3 temp = new Vector3(0, 0, 0);

    Vector3 rot = new Vector3(0, 0, 0);

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        rot.y = Random.Range(0, 4) * 90;

        transform.rotation = Quaternion.Euler(rot);

        speed = GameObject.Find("Terrain Manager").GetComponent<TerrainManager>().terrainSpeed;

        temp = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().isPaused == false)
        {
            temp.z -= speed * Time.deltaTime;
            transform.position = temp;
        }

        if (transform.position.z < -150)
        {

            Destroy(gameObject);
        }

    }
}
