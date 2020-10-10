using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public AudioSource hoverSFX;

    public void ExitGame()
    {
        if (gameObject.GetComponent<CanvasGroup>().alpha == 1)
        {
            SceneManager.LoadScene("Title_Screen");
        }
    }

    public void Restart()
    {
        if (gameObject.GetComponent<CanvasGroup>().alpha == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void PlayHoverSFX()
    {
        if (gameObject.GetComponent<CanvasGroup>().alpha == 1)
        {
            hoverSFX.Play();
        }
    }
}
