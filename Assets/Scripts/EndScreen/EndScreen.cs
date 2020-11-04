using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        
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

        SceneManager.LoadScene(NextLevel);
    }

    public void PlayHoverSFX()
    {

            hoverSFX.Play();
        
    }

}
