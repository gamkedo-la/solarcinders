using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSound : MonoBehaviour
{

    public AudioSource hoverSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHoverSFX()
    {
        if (gameObject.GetComponent<CanvasGroup>().alpha == 1)
        {
            hoverSFX.Play();
        }
    }

}
