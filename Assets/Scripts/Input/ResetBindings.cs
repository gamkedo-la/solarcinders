using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ResetBindings : MonoBehaviour
{
    public delegate void ResetAction();
    public static event ResetAction OnReset;

    public InputActionAsset playerInputActions;
    private InputActionMap playerActionMap;

    public GameObject MouseOn;
    public GameObject MouseOff;

    private void Start()
    {
        playerActionMap = playerInputActions.FindActionMap("Player");
    }

    public void ResetAllBindings()
    {
        playerActionMap.RemoveAllBindingOverrides();

        PlayerPrefs.SetInt("MouseControl", -1);

        MouseOff.GetComponent<Button>().interactable = true;
        MouseOn.GetComponent<Button>().interactable = false;

        if (OnReset != null)
        {
            OnReset();
        }
    }
}
