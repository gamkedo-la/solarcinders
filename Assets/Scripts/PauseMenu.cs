using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;


    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 1;
            Time.timeScale = 0;
            foreach (var btn in gameObject.GetComponentsInChildren<Button>())
            {
                btn.interactable = true;
            }
        }
        else
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 0;
            Time.timeScale = 1;
            foreach(var btn in gameObject.GetComponentsInChildren<Button>())
            {
                btn.interactable = false;
            }
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

    public void Restart()
    {
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
