using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Level2intro : MonoBehaviour
{

    GameObject Player;
    PlayerInput[] playerInputs;

    GameObject ship;
    GameObject CF;
    GameObject ST;
    GameObject MC;

    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.Find("PlayerManager");
        //Player.GetComponent<PlayerManager>().enabled = false;
        playerInputs = Player.GetComponentsInChildren<PlayerInput>();
        foreach (var playerInput in playerInputs)
        {
            playerInput.enabled = false;
        }

        ship = GameObject.Find("Ship");
        ST = GameObject.Find("shipTarget");
        CF = GameObject.Find("CrosshairFar");
        MC = GameObject.Find("Main Camera");


        MC.GetComponent<CameraMovement>().enabled = false;
        CF.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(ship.transform.position, ST.transform.position) < .2f)
        {

            MC.GetComponent<CameraMovement>().enabled = true;
            CF.SetActive(true);
            //Player.GetComponent<PlayerManager>().enabled = true;
            foreach (var playerInput in playerInputs)
            {
                playerInput.enabled = true;
            }


        }

    }
}
