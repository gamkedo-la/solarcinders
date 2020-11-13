using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseConButton : MonoBehaviour
{

    public GameObject other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Switch()
    {

        PlayerPrefs.SetInt("MouseControl", PlayerPrefs.GetInt("MouseControl") * - 1);

        other.GetComponent<Button>().interactable = true;

        gameObject.GetComponent<Button>().interactable = false;

    }
}
