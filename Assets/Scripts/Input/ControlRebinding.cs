using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControlRebinding : MonoBehaviour
{
    public InputActionReference actionReference;
    public InputActionAsset playerInputActions;
    public TextMeshProUGUI bindingText;

    private InputActionMap playerActionMap;

    private void Start()
    {
        playerActionMap = playerInputActions.FindActionMap("Player");
        SetBindingText();
    }

    public void PerformRebinding()
    {
        playerActionMap.Disable();
        RemapButtonClicked(actionReference);
    }

    private void RemapButtonClicked(InputAction actionToRebind)
    {
        var rebindOperation = actionToRebind.PerformInteractiveRebinding()
                    // To avoid accidental input from mouse motion
                    .WithControlsExcluding("Mouse")
                    .OnMatchWaitForAnother(0.1f)
                    .Start();

        // Dispose the operation on completion.
        rebindOperation.OnComplete(
           operation =>
           {
               Debug.Log($"Rebound '{actionToRebind}' to '{operation.selectedControl}'");
               operation.Dispose();
               SetBindingText();
               playerActionMap.Enable();
           });
    }

    private void SetBindingText()
    {
        bindingText.text = InputControlPath.ToHumanReadableString(actionReference.action.bindings[0].effectivePath);
    }
}
