using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class EndScreen : MonoBehaviour
{

    public GameObject Score;

    public GameObject Accuracy;

    public GameObject LongestCombo;

    public GameObject Total;

    public GameObject buttons;

    bool End = false;

    float countUp;

    public string NextLevel;

    public AudioSource hoverSFX;

    bool next = false;

    public GameObject EndShip;


    public InputActionAsset playerInputActions;
    private InputActionMap playerActionMap;

    // Start is called before the first frame update
    void Start()
    {
        playerActionMap = playerInputActions.FindActionMap("Player");
        playerActionMap.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        if(End == true)
        {

            countUp += Time.deltaTime;

            if(countUp > .05f)
            {

                Score.SetActive(true);
                


            }
            if (countUp > 1.0f)
            {

                Accuracy.SetActive(true);


            }

            if (countUp > 1.5f)
            {

                LongestCombo.SetActive(true);


            }

            if (countUp > 2.0f)
            {

                Total.SetActive(true);


            }


            if (countUp > 3.0f)
            {

                buttons.SetActive(true);


            }





        }

        if(next == true && countUp >= 2.5f)
        {
            SceneManager.LoadScene(NextLevel);


        }




        
    }


    public void EndTheLevel()
    {


        End = true;





    }


    public void ExitGame()
    {

        SceneManager.LoadScene("Title_Screen");

    }

    public void Continue()
    {

        countUp = 0;
        next = true;


        Vector3 temp = GameObject.Find("Ship").transform.position;

        Destroy(GameObject.Find("Ship"));

        Instantiate(EndShip, temp, Quaternion.identity);


        GetComponent<CanvasGroup>().alpha = 0;


    }

    public void PlayHoverSFX()
    {

            hoverSFX.Play();
        
    }

}
