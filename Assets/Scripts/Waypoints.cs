using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{ 
    public float x;
    public float y;

    //public float yBound = 11;
    //public float xBound = 22;

    GameObject player;

    levelBounds SceneMan;

    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        SceneMan = GameObject.Find("SceneManager").GetComponent<levelBounds>();

        player = GameObject.Find("Ship");

    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
        {
            temp.z = transform.position.z;
            temp.y = player.transform.position.y + y;
            temp.x = player.transform.position.x + x;




            temp.x = Mathf.Clamp(temp.x, -SceneMan.x, SceneMan.x);
            temp.y = Mathf.Clamp(temp.y, (SceneMan.yMin), (SceneMan.yMax));

            transform.position = temp;
        }
    }
}
