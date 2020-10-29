using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class straight : MonoBehaviour
{


    Vector3 temp = new Vector3(0, 0, 0);

    public float speed;

    GameObject next;

    public int terrainSize;

    // Start is called before the first frame update
    void Start()
    {

        temp = transform.position;
        //transform.eulerAngles.Set(0, 60, 0);
        //transform.rotation = Quaternion.Euler(0, 60, 0);
        speed = GameObject.Find("Terrain Manager").GetComponent<TerrainManager>().terrainSpeed;

        next = transform.Find("next").gameObject;

        temp.z += terrainSize;

        next.transform.position = temp;

        temp = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Title_Screen" &&
            GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().isPaused == false)
        {
            temp.z -= speed * Time.deltaTime;
            transform.position = temp;
        }

        if (transform.position.z < -150)
        {

            Destroy(gameObject);
        }

    }

    /*public void OnTriggerEnter(Collider other)
    {

        if (other.name == "Ship")
        {
            GameObject.Find("Terrain Manager").GetComponent<TerrainManager>().SpawnTerrain();
        }
    }*/
}
