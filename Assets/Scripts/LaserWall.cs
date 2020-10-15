using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWall : MonoBehaviour
{
    public float speed = 1.0f;

    Vector3 temp = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

        speed = GameObject.Find("Terrain Manager").GetComponent<TerrainManager>().terrainSpeed * -1;
        //temp = new Vector3(transform.position.x, transform.position.y, GameObject.Find("SceneManager").GetComponent<levelBounds>().z + 100);
        temp = transform.position;
        temp.z = GameObject.Find("SceneManager").GetComponent<levelBounds>().z + 100;

    }

    // Update is called once per frame
    private void Update()
    {
        
    
        if (GetComponent<EnemyBase>().Active == true)
        {
            temp.z += speed * Time.fixedDeltaTime;
            transform.position = temp;
        }

        if (transform.position.z < 0)
        {

            Despawn();
        }
    }



    void Despawn()
    {

        Destroy(gameObject);
    }
}
