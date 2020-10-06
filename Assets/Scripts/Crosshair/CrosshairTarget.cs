using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairTarget : MonoBehaviour
{

    public Transform Anchor;
    Vector3 temp = new Vector3(0,0,0);
    public int sense = 15;

    GameObject player;

    public int yBound = 20;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("ship");

    }

    // Update is called once per frame
    void Update()
    {

        /*  if(player.GetComponent<PlayerManager>().rolling == true)
          {

              sense = 5;

          }
          else
          {

              sense = 15;

          }
          */

        temp = Anchor.transform.position;

        
                                                                 
            if (((Input.GetAxis("Horizontal") * sense) > 1) || ((Input.GetAxis("Horizontal") * sense) < -1))
            {
                temp.x += Input.GetAxis("Horizontal") * sense;
            }

            if (((Input.GetAxis("Vertical") * sense) > 1) || ((Input.GetAxis("Vertical") * sense) < -1))
            {
                temp.y += Input.GetAxis("Vertical") * sense;
            }

            temp.y = Mathf.Clamp(temp.y, -yBound, yBound);

        
        
        gameObject.transform.position = temp;
    }
}
