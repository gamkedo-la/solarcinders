using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 1;
            Time.timeScale = 0;
        }
        else
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 0;
            Time.timeScale = 1;
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
    }

    public void ExitGame()
    {
        isPaused = false;
        SceneManager.LoadScene("Title_Screen");
    }
}
