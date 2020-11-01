using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetBindings : MonoBehaviour
{
    public delegate void ResetAction();
    public static event ResetAction OnReset;

    public InputActionAsset playerInputActions;
    private InputActionMap playerActionMap;

    private void Start()
    {
        playerActionMap = playerInputActions.FindActionMap("Player");
    }

    public void ResetAllBindings()
    {
        playerActionMap.RemoveAllBindingOverrides();

        if (OnReset != null)
        {
            OnReset();
        }
    }
}
