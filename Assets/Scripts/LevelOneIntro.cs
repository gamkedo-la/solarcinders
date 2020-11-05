using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class LevelOneIntro : MonoBehaviour
{

    public GameObject[] lights;

    public float lightTimer;
    public float lightReset;

    public float t;

    public float y;

    public float tt;

    Vector3 temp = new Vector3(0, 0, 0);

    float speed;

    int LT = 0;

    public GameObject crosshairFar;

    public GameObject spot;

    bool L = false;

    public GameObject DoorL;
    public GameObject DoorR;

    Vector3 tempL;
    Vector3 tempR;

    public AudioSource engine;

    bool ES;

    public InputActionAsset playerInputActions;
    private InputActionMap playerActionMap;

    // Start is called before the first frame update
    void Start()
    {
        playerActionMap = playerInputActions.FindActionMap("Player");
        playerActionMap.Disable();
        temp = transform.position;

        y = temp.y;

        crosshairFar.SetActive(false);
        spot.SetActive(false);

        tempL = DoorL.transform.position;
        tempR = DoorR.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(t > -0.5f && L == false)
        {
            spot.SetActive(true);
            L = true;
            engine.Play();
            GameObject.Find("Ship").GetComponent<PlayerManager>().engine.Play();
        }

        if (t <= 1)
        {
            temp.y = Mathf.Lerp(0, -2, t);
            t += Time.deltaTime;

            transform.position = temp;
        }
        if (t > 1)
        {

            speed = Mathf.Lerp(0, 600, tt);

            tt += (Time.deltaTime / 5);

            temp.z -= speed * Time.deltaTime;

            transform.position = temp;

            t += Time.deltaTime;

        }

        if (t > 1.5f)
        {
            tempL = DoorL.transform.position;
            tempR = DoorR.transform.position;

            tempL.x -= 4.5f * Time.deltaTime;

            tempR.x += 4.5f * Time.deltaTime;



            DoorL.transform.position = tempL;
            DoorR.transform.position = tempR;

        }

        lightTimer -= Time.deltaTime;

        if(lightTimer <= 0 && LT < 5)
        {
            lights[LT].SetActive(true);
            LT++;

            lightReset *= 0.84f ;
            lightTimer = lightReset;
            

        }

        if(transform.position.z < -200)
        {
            crosshairFar.SetActive(true);
            playerActionMap.Enable();
            engine.volume -= Time.deltaTime * 10;
            
        }
        if(transform.position.z < -500)
        {

            Destroy(gameObject);
        }




    }
}
