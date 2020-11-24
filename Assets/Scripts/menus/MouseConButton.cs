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

        PlayerPrefs.SetInt("MouseCon", PlayerPrefs.GetInt("MouseCon") * - 1);

        Debug.Log(PlayerPrefs.GetInt("MouseCon"));

        other.GetComponent<Button>().interactable = true;

        gameObject.GetComponent<Button>().interactable = false;

    }
}
